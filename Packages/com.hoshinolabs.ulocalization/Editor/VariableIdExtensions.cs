using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    internal static class VariableIdExtensions {
        public static object Pack<T>(this VariableId<T> self) where T : LocalizedMonoBehaviour {
            if (self == null || self.LocalizedEvent == null) {
                return null;
            }
            switch (self.LocalizedEvent) {
                case LocalizeStringEvent localizeStringEvent: {
                        if (!localizeStringEvent.StringReference.TryGetValue(self.VariableName, out var variable)
                            || variable == null
                            || !variable.TryGetRuntimeVariableId(out var variableId)) {
                            return null;
                        }
                        return new object[] {
                            variableId,
                        };
                    }
                case LocalizeDropdownEvent localizeDropdownEvent: {
                        Guid.TryParse(self.TableReferenceId, out var tableReferenceId);
                        long.TryParse(self.EntryReferenceId, out var entryReferenceId);
                        var localizedString = new LocalizedString(tableReferenceId, entryReferenceId);
                        localizedString = localizeDropdownEvent.Options
                            .Select(x => x.Text)
                            .FirstOrDefault(x => LocalizedReferenceExtensions.Equals(x, localizedString));
                        if (localizedString == null
                            || !localizedString.TryGetValue(self.VariableName, out var variable)
                            || variable == null
                            || !variable.TryGetRuntimeVariableId(out var variableId)) {
                            return null;
                        }
                        return new object[] {
                            variableId,
                        };
                    }
            }
            return null;
        }

        public static VariableId<T> UnPack<T>(object obj) where T : LocalizedMonoBehaviour {
            return null;
        }
    }
}
