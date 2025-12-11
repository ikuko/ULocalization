namespace HoshinoLabs.ULocalization.Udon {
    public static class BoolVariableExtensions {
        public static bool GetValue(this BoolVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid BoolVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (bool)_localization.GetValue(_variable);
        }

        public static void SetValue(this BoolVariable self, bool value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid BoolVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
