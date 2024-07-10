using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization.Udon {
    public static class ILocalizationExtensions {
        public static T GetVariable<T>(this ILocalization self, VariableId<LocalizeStringEvent> id) {
            return (T)self.GetVariable(id);
        }

        public static T GetVariable<T>(this ILocalization self, VariableId<LocalizeDropdownEvent> id) {
            return (T)self.GetVariable(id);
        }
    }
}
