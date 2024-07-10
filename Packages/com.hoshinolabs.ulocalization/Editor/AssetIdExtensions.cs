using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using VRC.SDK3.Data;

namespace HoshinoLabs.ULocalization {
    internal static class AssetIdExtensions {
        public static object Pack<T>(this AssetId<T> self) where T : LocalizedReference {
            if (self == null || self.LocalizedReference == null || self.LocalizedReference.IsEmpty
                || !self.LocalizedReference.TryGetRuntimeAssetId(out var assetId)) {
                return null;
            }
            switch (self.LocalizedReference) {
                case LocalizedString localizedString: {
                        LocalizationPreBuilder.RegisterAssetId(self);
                        var values = new DataDictionary();
                        foreach (KeyValuePair<string, IVariable> x in localizedString) {
                            if (x.Value != null && LocalizationHelper.ReferenceVariableIds.TryGetValue(x.Value, out var variableId)) {
                                values.Add(x.Key, variableId);
                            }
                        }
                        return new object[] {
                            assetId,
                            values.Count == 0 ? null : values,
                        };
                    }
                default: {
                        return new object[] {
                            assetId,
                        };
                    }
            }
        }

        public static AssetId<T> UnPack<T>(object obj) where T : LocalizedReference {
            return null;
        }

        public static AssetId UnPack(object obj) {
            return null;
        }
    }
}
