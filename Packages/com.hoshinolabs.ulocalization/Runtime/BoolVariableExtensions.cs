using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class BoolVariableExtensions {
        public static bool GetValue(this BoolVariable self) {
            return self.Value;
        }

        public static void SetValue(this BoolVariable self, bool value) {
            self.Value = value;
        }
    }
}
