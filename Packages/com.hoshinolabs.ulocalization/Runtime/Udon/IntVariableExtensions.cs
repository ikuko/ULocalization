namespace HoshinoLabs.ULocalization.Udon {
    public static class IntVariableExtensions {
        public static bool GetValue(this IntVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid IntVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (bool)_localization.GetVariable(_variable);
        }

        public static void SetValue(this IntVariable self, bool value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid IntVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetVariable(_variable, value);
        }
    }
}
