using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.Localization {
    public static class LocalizedReferenceExtensions {
        //public static bool TryGetRuntimeAssetId(this LocalizedReference self, out int assetId) {
        //    var tableId = self.TableReference.TableCollectionName;
        //    var entryId = self.TableEntryReference.KeyId.ToString();
        //    return LocalizationTypeResolver.ReferenceIds.TryGetValue((tableId, entryId), out assetId);
        //}

        //public static int GetRuntimeAssetId(this LocalizedReference self) {
        //    if (self.TryGetRuntimeAssetId(out var assetId)) {
        //        return assetId;
        //    }
        //    throw new Exception("Asset ID could not be found.");
        //}
    }
}
