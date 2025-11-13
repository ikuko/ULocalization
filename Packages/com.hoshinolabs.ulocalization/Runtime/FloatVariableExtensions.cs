using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class FloatVariableExtensions {
        public static float GetValue(this FloatVariable self) {
            return self.Value;
        }

        public static void SetValue(this FloatVariable self, float value) {
            self.Value = value;
        }
    }
}
