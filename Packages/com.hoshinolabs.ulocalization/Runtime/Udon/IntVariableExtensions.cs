namespace HoshinoLabs.ULocalization.Udon {
    public static class IntVariableExtensions {
        public static int GetValue(this IntVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid IntVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (int)_localization.GetVariable(_variable);
        }

        public static void SetValue(this IntVariable self, int value) {
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
