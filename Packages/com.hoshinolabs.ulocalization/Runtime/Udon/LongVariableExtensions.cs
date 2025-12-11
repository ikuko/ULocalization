namespace HoshinoLabs.ULocalization.Udon {
    public static class LongVariableExtensions {
        public static long GetValue(this LongVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LongVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (long)_localization.GetValue(_variable);
        }

        public static void SetValue(this LongVariable self, long value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LongVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
