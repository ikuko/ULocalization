using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class StringVariableExtensions {
        public static string GetValue(this StringVariable self) {
            return self.Value;
        }

        public static void SetValue(this StringVariable self, string value) {
            self.Value = value;
        }
    }
}
