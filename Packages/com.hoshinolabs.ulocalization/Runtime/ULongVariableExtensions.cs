using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class ULongVariableExtensions {
        public static ulong GetValue(this ULongVariable self) {
            return self.Value;
        }

        public static void SetValue(this ULongVariable self, ulong value) {
            self.Value = value;
        }
    }
}
