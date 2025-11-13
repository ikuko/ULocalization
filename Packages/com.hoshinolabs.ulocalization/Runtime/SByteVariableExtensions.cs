using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class SByteVariableExtensions {
        public static sbyte GetValue(this SByteVariable self) {
            return self.Value;
        }

        public static void SetValue(this SByteVariable self, sbyte value) {
            self.Value = value;
        }
    }
}
