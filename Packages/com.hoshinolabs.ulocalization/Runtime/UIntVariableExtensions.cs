using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class UIntVariableExtensions {
        public static uint GetValue(this UIntVariable self) {
            return self.Value;
        }

        public static void SetValue(this UIntVariable self, uint value) {
            self.Value = value;
        }
    }
}
