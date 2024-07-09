using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UdonSharp;
using UdonSharpEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.Localization.Tables;
using UnityEngine.SceneManagement;

namespace HoshinoLabs.ULocalization {
    internal sealed class LocalizationPreBuilder : IProcessSceneWithReport {
        public int callbackOrder => -5000;

        public void OnProcessScene(Scene scene, BuildReport report) {
            if (!LocalizationSettings.HasSettings) {
                LocalizationHelper.AvailableLocales = default;
                LocalizationHelper.ReferenceGroupIds = default;
                LocalizationHelper.ReferenceVariableIds = default;
                LocalizationHelper.ReferenceStringIds = default;
                LocalizationHelper.ReferenceAssetIds = default;
                LocalizationHelper.StringDatabase = default;
                LocalizationHelper.AssetDatabase = default;
                return;
            }

            LocalizationHelper.AvailableLocales = BuildAvailableLocales();
            LocalizationHelper.ReferenceGroupIds = BuildGroupIds();
            LocalizationHelper.ReferenceVariableIds = BuildReferenceVariableIds();
            var stringEntries = CollectAllStringEntry();
            var assetEntries = CollectAllAssetEntry();
            LocalizationHelper.ReferenceStringIds = BuildReferenceStringIds(stringEntries);
            LocalizationHelper.ReferenceAssetIds = BuildReferenceAssetIds(assetEntries);
            LocalizationHelper.StringDatabase = BuildStringDatabase(stringEntries);
            LocalizationHelper.AssetDatabase = BuildAssetDatabase();

            foreach (var udon in SceneManager.GetActiveScene().GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren<UdonSharpBehaviour>(true))
                .Where(x => UdonSharpEditorUtility.IsProxyBehaviour(x))) {
                var serializationPolicy = ProxySerializationPolicy.Default;
                var isPreBuildSerializeProperty = serializationPolicy.GetType().GetProperty("IsPreBuildSerialize");
                isPreBuildSerializeProperty.SetValue(serializationPolicy, true);
                UdonSharpEditorUtility.CopyProxyToUdon(udon, serializationPolicy);
            }
        }

        internal static void RegisterAssetId<T>(AssetId<T> assetId) where T : LocalizedReference {
            switch (assetId.LocalizedReference) {
                case LocalizedString localizedString: {
                        var referenceVariableIds = LocalizationHelper.ReferenceVariableIds;
                        var offset = referenceVariableIds.Count;
                        var variableIds = localizedString.Values
                            .Where(x => x.IsSupported())
                            .Where(x => !referenceVariableIds.ContainsKey(x))
                            .Select((v, i) => (v, i))
                            .ToDictionary(x => x.v, x => offset + x.i);
                        foreach (var (k, v) in variableIds) {
                            referenceVariableIds.Add(k, v);
                        }
                        break;
                    }
            }
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
            return LocalizationEditorSettings.GetStringTableCollections()
                .SelectMany(table => {
                    return table.SharedData.Entries.Select(entry => {
                        return new TableEntry(
                            tableId: table.TableCollectionName,
                            entryId: entry.Id.ToString(),
                            name: entry.Key
                        );
                    });
                })
                .ToArray();
        }

        static TableEntry[] CollectAllAssetEntry() {
            return LocalizationEditorSettings.GetAssetTableCollections()
                .SelectMany(table => {
                    return table.SharedData.Entries.Select(entry => {
                        return new TableEntry(
                            tableId: table.TableCollectionName,
                            entryId: entry.Id.ToString(),
                            name: entry.Key
                        );
                    });
                })
                .ToArray();
        }

        static Dictionary<(string tableId, string entryId), int> BuildReferenceStringIds(TableEntry[] stringEntries) {
            return stringEntries
                .Select((v, i) => (v, i))
                .ToDictionary(x => (x.v.TableId, x.v.EntryId), x => x.i);
        }

        static Dictionary<(string tableId, string entryId), int> BuildReferenceAssetIds(TableEntry[] assetEntries) {
            return assetEntries
                .Select((v, i) => (v, i))
                .ToDictionary(x => (x.v.TableId, x.v.EntryId), x => x.i);
        }

        static Dictionary<LocalizedMonoBehaviour, int> BuildGroupIds() {
            return new LocalizedMonoBehaviour[][] {
                    GameObject.FindObjectsOfType<LocalizeStringEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeAudioClipEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeTextureEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeSpriteEvent>(true),
                    GameObject.FindObjectsOfType<LocalizeDropdownEvent>(true),
                }
                .SelectMany(x => x)
                .Select((v, i) => (v, i))
                .ToDictionary(x => x.v, x => x.i);
        }

        static IEnumerable<IVariable> BuildReferenceVariableIds(LocalizeStringEvent localizeString) {
            return localizeString.StringReference.Values;
        }
        static IEnumerable<IVariable> BuildReferenceVariableIds(LocalizeDropdownEvent localizeDropdown) {
            return localizeDropdown.Options
                .SelectMany(x => x.Text.Values);
        }

        static Dictionary<IVariable, int> BuildReferenceVariableIds() {
            return LocalizationHelper.ReferenceGroupIds
                .Keys
                .Select(x => {
                    switch (x) {
                        case LocalizeStringEvent localizeString: {
                                return BuildReferenceVariableIds(localizeString);

                            }
                        case LocalizeDropdownEvent localizeDropdown: {
                                return BuildReferenceVariableIds(localizeDropdown);
                            }
                        default: {
                                return null;
                            }
                    }
                })
                .Where(x => x != null)
                .SelectMany(x => x)
                .Where(x => x.IsSupported())
                .Select((v, i) => (v, i))
                .ToDictionary(x => x.v, x => x.i);
        }

        static StringTableEntryData BuildStringTableEntryData(StringTableEntry entry) {
            var value = entry.Value;
            var smart = entry.IsSmart;
            return new StringTableEntryData(value, smart);
        }

        static StringTableEntryData BuildStringTableEntryData(Locale locale, int assetId, TableEntry[] stringEntries) {
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

        static StringTableEntryData[][] BuildStringDatabase(TableEntry[] stringEntries) {
            return LocalizationHelper.AvailableLocales.Select(locale => {
                var database = new StringTableEntryData[LocalizationHelper.ReferenceStringIds.Count];
                foreach (var table in CollectAllStringTable(locale)) {
                    var tableId = table.TableCollectionName;
                    foreach (var entry in table) {
                        var entryId = entry.Key.ToString();
                        var assetId = LocalizationHelper.ReferenceStringIds[(tableId, entryId)];
                        database[assetId] = BuildStringTableEntryData(entry.Value);
                    }
                }
                return database
                    .Select((v, i) => v == null ? BuildStringTableEntryData(locale, i, stringEntries) : v)
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
            return LocalizationHelper.AvailableLocales.Select(locale => {
                var database = new AssetTableEntryData[LocalizationHelper.ReferenceAssetIds.Count];
                foreach (var table in CollectAllAssetTable(locale)) {
                    var tableId = table.TableCollectionName;
                    foreach (var entry in table) {
                        var entryId = entry.Key.ToString();
                        var assetId = LocalizationHelper.ReferenceAssetIds[(tableId, entryId)];
                        database[assetId] = BuildAssetTableEntryData(table, entry.Value);
                    }
                }
                return database;
            }).ToArray();
        }
    }
}
