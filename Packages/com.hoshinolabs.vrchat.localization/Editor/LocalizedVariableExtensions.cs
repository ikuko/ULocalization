using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
    public static class LocalizedVariableExtensions {
        public static bool TryGetRuntimeVariableId(this LocalizeStringEvent self, int index, out int groupId) {
            return LocalizationHelper.ReferenceVariableIds.TryGetValue((self, index), out groupId);
        }

        public static int GetRuntimeVariableId(this LocalizeStringEvent self, int index) {
            if (self.TryGetRuntimeVariableId(index, out var groupId)) {
                return groupId;
            }
            throw new Exception("Variable ID could not be found.");
        }

        public static bool TryGetRuntimeVariableId(this LocalizeStringEvent self, string name, out int groupId) {
            var index = Array.IndexOf(self.StringReference.Keys.ToArray(), name);
            return self.TryGetRuntimeVariableId(index, out groupId);
        }

        public static int GetRuntimeVariableId(this LocalizeStringEvent self, string name) {
            if (self.TryGetRuntimeVariableId(name, out var groupId)) {
                return groupId;
            }
            throw new Exception("Variable ID could not be found.");
        }
    }
}
