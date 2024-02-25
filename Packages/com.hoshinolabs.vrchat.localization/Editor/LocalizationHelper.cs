using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat;
using UnityEngine.Localization.Tables;
using VRC.SDKBase.Editor.BuildPipeline;

namespace HoshinoLabs.Localization {
    public static class LocalizationHelper {
        static Locale[] availableLocales;
        static Dictionary<GlobalObjectId, int> referenceGroupIds;
        static TableEntry[] stringEntries;
        static TableEntry[] assetEntries;
        static Dictionary<(string tableId, string entryId), int> referenceStringIds;
        static Dictionary<(string tableId, string entryId), int> referenceAssetIds;
        static StringTableEntryData[][] stringDatabase;
        static AssetTableEntryData[][] assetDatabase;

        public static Locale[] AvailableLocales => availableLocales;
        internal static Dictionary<GlobalObjectId, int> ReferenceGroupIds => referenceGroupIds;
        internal static Dictionary<(string tableId, string entryId), int> ReferenceStringIds => referenceStringIds;
        internal static Dictionary<(string tableId, string entryId), int> ReferenceAssetIds => referenceAssetIds;
        internal static StringTableEntryData[][] StringDatabase => stringDatabase;
        internal static AssetTableEntryData[][] AssetDatabase => assetDatabase;

        internal class BuildInitializer : IVRCSDKBuildRequestedCallback {
            public int callbackOrder => 0;

            public bool OnBuildRequested(VRCSDKRequestedBuildType requestedBuildType) {
                Init();
                return true;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init() {
            availableLocales = BuildAvailableLocales();
            referenceGroupIds = BuildGroupIds();
            stringEntries = CollectAllStringEntry();
            assetEntries = CollectAllAssetEntry();
            referenceStringIds = BuildReferenceStringIds();
            referenceAssetIds = BuildReferenceAssetIds();
            stringDatabase = BuildStringDatabase();
            assetDatabase = BuildAssetDatabase();
        }

        static Locale[] BuildAvailableLocales() {
            return LocalizationSettings.AvailableLocales.Locales
                .Select(x => new Locale(x.Identifier.CultureInfo.EnglishName, x.Identifier.Code, x.Identifier.CultureInfo))
                .ToArray();
        }

        static StringTable[] CollectAllStringTable(Locale locale) {
            return LocalizationEditorSettings.GetStringTableCollections()
                .Select(x => x.StringTables.Where(x => x.LocaleIdentifier.Code == locale.Code).FirstOrDefault())
                .Where(x => x)
                .ToArray();
        }

        static AssetTable[] CollectAllAssetTable(Locale locale) {
            return LocalizationEditorSettings.GetAssetTableCollections()
                .Select(x => x.AssetTables.Where(x => x.LocaleIdentifier.Code == locale.Code).FirstOrDefault())
                .Where(x => x)
                .ToArray();
        }

        static TableEntry[] CollectAllStringEntry() {
            return new[] {
                availableLocales
                    .Select(x => CollectAllStringTable(x))
                    .SelectMany(x => x)
                    .Select(table => table.Select(x => (
                        tableId: table.TableCollectionName,
                        entryId: x.Key.ToString(),
                        name: x.Value.Key
                    )))
                    .SelectMany(x => x),
                referenceGroupIds
                    .Select(x => GlobalObjectId.GlobalObjectIdentifierToObjectSlow(x.Key))
                    .OfType<LocalizeStringEvent>()
                    .Where(x => x != null)
                    .Select(x => x.StringReference)
                    .Where(x => x.TableReference.ReferenceType == TableReference.Type.Guid)
                    .Where(x => x.TableEntryReference.ReferenceType == TableEntryReference.Type.Id)
                    .Select(x => (
                        tableId: x.TableReference.TableCollectionName,
                        entryId: x.TableEntryReference.KeyId.ToString(),
                        name: x.TableEntryReference.Key
                    ))
            }
            .SelectMany(x => x)
            .GroupBy(x => (x.tableId, x.entryId))
            .Select(x => x.First())
            .Select(x => new TableEntry(x.name, x.tableId, x.entryId))
            .ToArray();
        }

        static TableEntry[] CollectAllAssetEntry() {
            return new[] {
                availableLocales
                    .Select(x => CollectAllAssetTable(x))
                    .SelectMany(x => x)
                    .Select(table => table.Select(x => (
                        tableId: table.TableCollectionName,
                        entryId: x.Key.ToString(),
                        name: x.Value.Key
                    )))
                    .SelectMany(x => x),
                referenceGroupIds
                    .Select(x => GlobalObjectId.GlobalObjectIdentifierToObjectSlow(x.Key))
                    .OfType<LocalizeAudioClipEvent>()
                    .Where(x => x != null)
                    .Select(x => x.AssetReference)
                    .Where(x => x.TableReference.ReferenceType == TableReference.Type.Guid)
                    .Where(x => x.TableEntryReference.ReferenceType == TableEntryReference.Type.Id)
                    .Select(x => (
                        tableId: x.TableReference.TableCollectionName,
                        entryId: x.TableEntryReference.KeyId.ToString(),
                        name: x.TableEntryReference.Key
                    )),
                referenceGroupIds
                    .Select(x => GlobalObjectId.GlobalObjectIdentifierToObjectSlow(x.Key))
                    .OfType<LocalizeTextureEvent>()
                    .Where(x => x != null)
                    .Select(x => x.AssetReference)
                    .Where(x => x.TableReference.ReferenceType == TableReference.Type.Guid)
                    .Where(x => x.TableEntryReference.ReferenceType == TableEntryReference.Type.Id)
                    .Select(x => (
                        tableId: x.TableReference.TableCollectionName,
                        entryId: x.TableEntryReference.KeyId.ToString(),
                        name: x.TableEntryReference.Key
                    )),
                referenceGroupIds
                    .Select(x => GlobalObjectId.GlobalObjectIdentifierToObjectSlow(x.Key))
                    .OfType<LocalizeSpriteEvent>()
                    .Where(x => x != null)
                    .Select(x => x.AssetReference)
                    .Where(x => x.TableReference.ReferenceType == TableReference.Type.Guid)
                    .Where(x => x.TableEntryReference.ReferenceType == TableEntryReference.Type.Id)
                    .Select(x => (
                        tableId: x.TableReference.TableCollectionName,
                        entryId: x.TableEntryReference.KeyId.ToString(),
                        name: x.TableEntryReference.Key
                    ))
            }
            .SelectMany(x => x)
            .GroupBy(x => (x.tableId, x.entryId))
            .Select(x => x.First())
            .Select(x => new TableEntry(x.name, x.tableId, x.entryId))
            .ToArray();
        }

        static Dictionary<(string tableId, string entryId), int> BuildReferenceStringIds() {
            return stringEntries
                .Select((v, i) => (v, i))
                .ToDictionary(x => (x.v.TableId, x.v.EntryId), x => x.i);
        }

        static Dictionary<(string tableId, string entryId), int> BuildReferenceAssetIds() {
            return assetEntries
                .Select((v, i) => (v, i))
                .ToDictionary(x => (x.v.TableId, x.v.EntryId), x => x.i);
        }

        static Dictionary<GlobalObjectId, int> BuildGroupIds() {
            return new LocalizedMonoBehaviour[][] {
                    GameObject.FindObjectsOfType<LocalizeAudioClipEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeStringEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeTextureEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeSpriteEvent>(true),
                }
                .SelectMany(x => x)
                .Select(x => GlobalObjectId.GetGlobalObjectIdSlow(x))
                .Select((v, i) => (v, i))
                .ToDictionary(x => x.v, x => x.i);
        }

        static StringTableEntryData BuildStringTableEntryData(StringTableEntry entry) {
            var value = entry.Value;
            var smart = entry.IsSmart;
            return new StringTableEntryData(value, smart);
        }

        static StringTableEntryData BuildStringTableEntryData(Locale locale, int assetId) {
            var args = new Dictionary<string, object>() {
                ["key"] = stringEntries[assetId].Name ?? string.Empty,
                ["keyId"] = stringEntries[assetId].EntryId,
                ["table"] = new Dictionary<string, object> {
                    ["TableCollectionName"] = stringEntries[assetId].TableId,
                },
                ["locale"] = locale,
            };
            var value = LocalizationSettings.StringDatabase.NoTranslationFoundMessage.FormatSmart(args);
            return new StringTableEntryData(value, false);
        }

        static StringTableEntryData[][] BuildStringDatabase() {
            return availableLocales.Select(locale => {
                var database = new StringTableEntryData[referenceStringIds.Count];
                foreach (var table in CollectAllStringTable(locale)) {
                    var tableId = table.TableCollectionName;
                    foreach (var entry in table) {
                        var entryId = entry.Key.ToString();
                        var assetId = referenceStringIds[(tableId, entryId)];
                        database[assetId] = BuildStringTableEntryData(entry.Value);
                    }
                }
                return database
                    .Select((v, i) => v == null ? BuildStringTableEntryData(locale, i) : v)
                    .ToArray();
            }).ToArray();
        }

        static AssetTableEntryData BuildAssetTableEntryData(AssetTable table, AssetTableEntry entry) {
            var assetType = LocalizationEditorSettings.GetAssetTableCollection(table.SharedData.TableCollectionNameGuid).GetEntryAssetType(entry.Key);
            var assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(entry.Guid);
            var value = UnityEditor.AssetDatabase.LoadAssetAtPath(assetPath, assetType);
            return new AssetTableEntryData(value);
        }

        static AssetTableEntryData[][] BuildAssetDatabase() {
            return availableLocales.Select(locale => {
                var database = new AssetTableEntryData[referenceAssetIds.Count];
                foreach (var table in CollectAllAssetTable(locale)) {
                    var tableId = table.TableCollectionName;
                    foreach (var entry in table) {
                        var entryId = entry.Key.ToString();
                        var assetId = referenceAssetIds[(tableId, entryId)];
                        database[assetId] = BuildAssetTableEntryData(table, entry.Value);
                    }
                }
                return database;
            }).ToArray();
        }
    }
}
