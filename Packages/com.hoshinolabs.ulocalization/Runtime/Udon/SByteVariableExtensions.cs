namespace HoshinoLabs.ULocalization.Udon {
    public static class SByteVariableExtensions {
        public static sbyte GetValue(this SByteVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid SByteVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (sbyte)_localization.GetValue(_variable);
        }

        public static void SetValue(this SByteVariable self, sbyte value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid SByteVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
