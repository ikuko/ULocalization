namespace HoshinoLabs.ULocalization.Udon {
    public static class DoubleVariableExtensions {
        public static double GetValue(this DoubleVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid DoubleVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (double)_localization.GetValue(_variable);
        }

        public static void SetValue(this DoubleVariable self, double value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid DoubleVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
