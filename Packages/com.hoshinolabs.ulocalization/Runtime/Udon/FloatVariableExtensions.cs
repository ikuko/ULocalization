namespace HoshinoLabs.ULocalization.Udon {
    public static class FloatVariableExtensions {
        public static float GetValue(this FloatVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid FloatVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (float)_localization.GetValue(_variable);
        }

        public static void SetValue(this FloatVariable self, float value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid FloatVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
