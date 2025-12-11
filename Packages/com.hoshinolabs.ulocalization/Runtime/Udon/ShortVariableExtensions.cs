namespace HoshinoLabs.ULocalization.Udon {
    public static class ShortVariableExtensions {
        public static short GetValue(this BoolVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid ShortVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (short)_localization.GetValue(_variable);
        }

        public static void SetValue(this ShortVariable self, short value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid ShortVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
