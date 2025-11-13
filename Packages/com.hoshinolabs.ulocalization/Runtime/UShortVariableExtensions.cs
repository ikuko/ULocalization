using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class UShortVariableExtensions {
        public static ushort GetValue(this UShortVariable self) {
            return self.Value;
        }

        public static void SetValue(this UShortVariable self, ushort value) {
            self.Value = value;
        }
    }
}
