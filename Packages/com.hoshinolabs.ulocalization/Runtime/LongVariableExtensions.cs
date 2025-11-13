using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class LongVariableExtensions {
        public static long GetValue(this LongVariable self) {
            return self.Value;
        }

        public static void SetValue(this LongVariable self, long value) {
            self.Value = value;
        }
    }
}
