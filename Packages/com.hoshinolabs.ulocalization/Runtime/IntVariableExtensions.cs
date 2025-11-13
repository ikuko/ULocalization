using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class IntVariableExtensions {
        public static int GetValue(this IntVariable self) {
            return self.Value;
        }

        public static void SetValue(this IntVariable self, int value) {
            self.Value = value;
        }
    }
}
