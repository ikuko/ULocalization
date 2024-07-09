using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    internal static class AssetIdExtensions {
        public static object Pack<T>(this AssetId<T> self) where T : LocalizedReference {
            if (self == null || self.LocalizedReference == null || self.LocalizedReference.IsEmpty
                || !self.LocalizedReference.TryGetRuntimeAssetId(out var assetId)) {
                return null;
            }
            LocalizationPreBuilder.RegisterAssetId(self);
            var variableIds = new List<int>();
            switch (self.LocalizedReference) {
                case LocalizedString localizedString: {
                        foreach (var variable in localizedString.Values) {
                            if (!variable.TryGetRuntimeVariableId(out var variableId)) {
                                return null;
                            }
                            variableIds.Add(variableId);
                        }
                        break;
                    }
            }
            return new object[] {
                assetId,
                variableIds.ToArray(),
            };
        }

        public static AssetId<T> UnPack<T>(object obj) where T : LocalizedReference {
            return null;
        }
    }
}
