using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace HoshinoLabs.Localization {
    public static class LocalizedReferenceExtensions {
        public static bool TryGetRuntimeAssetId(this LocalizedAudioClip self, out int assetId) {
            assetId = -1;
            if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
                return false;
            }
            if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return false;
            }
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        }

        public static int GetRuntimeAssetId(this LocalizedAudioClip self) {
            if (self.TryGetRuntimeAssetId(out var assetId)) {
                return assetId;
            }
            throw new Exception("Asset ID could not be found.");
        }

        public static bool TryGetRuntimeAssetId(this LocalizedString self, out int assetId) {
            assetId = -1;
            if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
                return false;
            }
            if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return false;
            }
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            return LocalizationHelper.ReferenceStringIds.TryGetValue((tableId, entryId), out assetId);
        }

        public static int GetRuntimeAssetId(this LocalizedString self) {
            if (self.TryGetRuntimeAssetId(out var assetId)) {
                return assetId;
            }
            throw new Exception("Asset ID could not be found.");
        }

        public static bool TryGetRuntimeAssetId(this LocalizedTexture self, out int assetId) {
            assetId = -1;
            if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
                return false;
            }
            if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return false;
            }
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        }

        public static int GetRuntimeAssetId(this LocalizedTexture self) {
            if (self.TryGetRuntimeAssetId(out var assetId)) {
                return assetId;
            }
            throw new Exception("Asset ID could not be found.");
        }

        public static bool TryGetRuntimeAssetId(this LocalizedSprite self, out int assetId) {
            assetId = -1;
            if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
                return false;
            }
            if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return false;
            }
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        }

        public static int GetRuntimeAssetId(this LocalizedSprite self) {
            if (self.TryGetRuntimeAssetId(out var assetId)) {
                return assetId;
            }
            throw new Exception("Asset ID could not be found.");
        }

        public static bool TryGetRuntimeAssetId<T, U>(this LocalizedAsset<T> self, out int assetId)
            where T : UnityEngine.Object
            where U : LocalizedAsset<T>, new() {
            assetId = -1;
            if (self.TableReference.ReferenceType != TableReference.Type.Guid) {
                return false;
            }
            if (self.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return false;
            }
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            return LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out assetId);
        }

        public static int GetRuntimeAssetId<T, U>(this LocalizedAsset<T> self)
            where T : UnityEngine.Object
            where U : LocalizedAsset<T>, new() {
            if (self.TryGetRuntimeAssetId<T, U>(out var assetId)) {
                return assetId;
            }
            throw new Exception("Asset ID could not be found.");
        }
    }
}
