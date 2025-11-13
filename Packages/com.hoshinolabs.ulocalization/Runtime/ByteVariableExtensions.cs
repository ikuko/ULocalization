using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class ByteVariableExtensions {
        public static byte GetValue(this ByteVariable self) {
            return self.Value;
        }

        public static void SetValue(this ByteVariable self, byte value) {
            self.Value = value;
        }
    }
}
