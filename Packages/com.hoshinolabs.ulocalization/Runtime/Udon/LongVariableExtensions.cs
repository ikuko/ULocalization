namespace HoshinoLabs.ULocalization.Udon {
    public static class LongVariableExtensions {
        public static bool GetValue(this LongVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LongVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (bool)_localization.GetVariable(_variable);
        }

        public static void SetValue(this LongVariable self, bool value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LongVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetVariable(_variable, value);
        }
    }
}
