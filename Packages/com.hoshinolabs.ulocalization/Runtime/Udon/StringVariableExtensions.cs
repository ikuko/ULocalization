namespace HoshinoLabs.ULocalization.Udon {
    public static class StringVariableExtensions {
        public static string GetValue(this StringVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid StringVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (string)_localization.GetValue(_variable);
        }

        public static void SetValue(this StringVariable self, string value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid StringVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
