using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class ObjectVariableExtensions {
        public static object GetValue(this ObjectVariable self) {
            return self.Value;
        }

        public static void SetValue(this ObjectVariable self, object value) {
            self.Value = (Object)value;
        }
    }
}
