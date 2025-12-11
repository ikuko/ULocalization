namespace HoshinoLabs.ULocalization.Udon {
    public static class ByteVariableExtensions {
        public static byte GetValue(this ByteVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid ByteVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (byte)_localization.GetValue(_variable);
        }

        public static void SetValue(this ByteVariable self, byte value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid ByteVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
