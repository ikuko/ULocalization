using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class LocalizedVariableExtensions {
        public static bool TryGetRuntimeVariableId(this IVariable self, out int variableId) {
            return LocalizationHelper.ReferenceVariableIds.TryGetValue(self, out variableId);
        }

        public static int GetRuntimeVariableId(this IVariable self) {
            if (self.TryGetRuntimeVariableId(out var variableId)) {
                return variableId;
            }
            throw new Exception("Variable ID could not be found.");
        }
    }
}
