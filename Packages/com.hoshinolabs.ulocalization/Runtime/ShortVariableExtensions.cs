using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class ShortVariableExtensions {
        public static short GetValue(this ShortVariable self) {
            return self.Value;
        }

        public static void SetValue(this ShortVariable self, short value) {
            self.Value = value;
        }
    }
}
