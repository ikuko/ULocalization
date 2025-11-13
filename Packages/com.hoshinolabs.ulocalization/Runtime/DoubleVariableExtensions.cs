using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class DoubleVariableExtensions {
        public static double GetValue(this DoubleVariable self) {
            return self.Value;
        }

        public static void SetValue(this DoubleVariable self, double value) {
            self.Value = value;
        }
    }
}
