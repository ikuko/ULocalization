using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace HoshinoLabs.ULocalization {
    public static class LocalizedReferenceExtensions {
        //public static bool TryGetRuntimeAssetId(this LocalizedAudioClip self, out int assetId) {
        //    assetId = -1;
        //    if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
        //        return false;
        //    }
        //    if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
        //        return false;
        //    }
        //    var tableId = self.TableReference.TableCollectionName;
        //    var entryId = self.TableEntryReference.KeyId.ToString();
        //    return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        //}

        //public static int GetRuntimeAssetId(this LocalizedAudioClip self) {
        //    if (self.TryGetRuntimeAssetId(out var assetId)) {
        //        return assetId;
        //    }
        //    throw new Exception("Asset ID could not be found.");
        //}

        //public static bool TryGetRuntimeAssetId(this LocalizedString self, out int assetId) {
        //    assetId = -1;
        //    if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
        //        return false;
        //    }
        //    if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
        //        return false;
        //    }
        //    var tableId = self.TableReference.TableCollectionName;
        //    var entryId = self.TableEntryReference.KeyId.ToString();
        //    return LocalizationHelper.ReferenceStringIds.TryGetValue((tableId, entryId), out assetId);
        //}

        //public static int GetRuntimeAssetId(this LocalizedString self) {
        //    if (self.TryGetRuntimeAssetId(out var assetId)) {
        //        return assetId;
        //    }
        //    throw new Exception("Asset ID could not be found.");
        //}

        //public static bool TryGetRuntimeAssetId(this LocalizedTexture self, out int assetId) {
        //    assetId = -1;
        //    if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
        //        return false;
        //    }
        //    if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
        //        return false;
        //    }
        //    var tableId = self.TableReference.TableCollectionName;
        //    var entryId = self.TableEntryReference.KeyId.ToString();
        //    return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        //}

        //public static int GetRuntimeAssetId(this LocalizedTexture self) {
        //    if (self.TryGetRuntimeAssetId(out var assetId)) {
        //        return assetId;
        //    }
        //    throw new Exception("Asset ID could not be found.");
        //}

        //public static bool TryGetRuntimeAssetId(this LocalizedSprite self, out int assetId) {
        //    assetId = -1;
        //    if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
        //        return false;
        //    }
        //    if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
        //        return false;
        //    }
        //    var tableId = self.TableReference.TableCollectionName;
        //    var entryId = self.TableEntryReference.KeyId.ToString();
        //    return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        //}

        //public static int GetRuntimeAssetId(this LocalizedSprite self) {
        //    if (self.TryGetRuntimeAssetId(out var assetId)) {
        //        return assetId;
        //    }
        //    throw new Exception("Asset ID could not be found.");
        //}

        //public static bool TryGetRuntimeAssetId<T, U>(this LocalizedAsset<T> self, out int assetId)
        //    where T : UnityEngine.Object
        //    where U : LocalizedAsset<T>, new() {
        //    assetId = -1;
        //    if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
        //        return false;
        //    }
        //    if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
        //        return false;
        //    }
        //    var tableId = self.TableReference.TableCollectionName;
        //    var entryId = self.TableEntryReference.KeyId.ToString();
        //    return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        //}

        //public static int GetRuntimeAssetId<T, U>(this LocalizedAsset<T> self)
        //    where T : UnityEngine.Object
        //    where U : LocalizedAsset<T>, new() {
        //    if (self.TryGetRuntimeAssetId<T, U>(out var assetId)) {
        //        return assetId;
        //    }
        //    throw new Exception("Asset ID could not be found.");
        //}

        public static bool TryGetRuntimeAssetId(this LocalizedReference self, out int assetId) {
            assetId = -1;
            if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
                return false;
            }
            if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return false;
            }
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            switch (self) {
                case LocalizedString localizedString: {
                        return LocalizationHelper.ReferenceStringIds.TryGetValue((tableId, entryId), out assetId);
                    }
                case LocalizedAssetBase localizedAsset: {
                        return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
                    }
            }
            return false;
        }

        public static int GetRuntimeAssetId(this LocalizedReference self) {
            if (self.TryGetRuntimeAssetId(out var assetId)) {
                return assetId;
            }
            throw new Exception("Asset ID could not be found.");
        }

        internal static bool Equals(LocalizedReference lhs, LocalizedReference rhs) {
            return lhs.TableReference.Equals(rhs.TableReference)
                && lhs.TableEntryReference.Equals(rhs.TableEntryReference);
        }

        internal static GUIContent ToLabel<T>(this LocalizedReference self, string format = "{0}") {
            var assetType = typeof(T);
            var icon = EditorGUIUtility.ObjectContent(null, assetType);
            var tableReference = self.TableReference;
            var tableEntryReference = self.TableEntryReference;
            var tableCollection = self.GetTableCollections()
                .FirstOrDefault(x => x.SharedData.TableCollectionNameGuid == tableReference);
            var tableEntry = tableCollection?.SharedData.GetEntry(tableEntryReference.KeyId);
            if (tableReference == null || tableEntry == null) {
                return new GUIContent(string.Format(format, $"None ({assetType.Name})", icon.image));
            }
            var tableEntryKey = tableEntry.Key;
            var idx = tableEntryKey.IndexOf('\n');
            if (0 < idx) {
                // We don't want a multiline label as it overflows in the UI.
                tableEntryKey = tableEntryKey.Substring(0, idx);
            }
            return new GUIContent(string.Format(format, $"{tableReference.TableCollectionName}\u2215{tableEntryKey}"), icon.image);
        }

        internal static IEnumerable<LocalizationTableCollection> GetTableCollections(this LocalizedReference self) {
            switch (self) {
                case LocalizedString localizedString: {
                        return LocalizationEditorSettings.GetStringTableCollections();
                    }
                case LocalizedAssetBase localizedAsset: {
                        return LocalizationEditorSettings.GetAssetTableCollections();
                    }
            }
            return new LocalizationTableCollection[] { };
        }
    }
}
