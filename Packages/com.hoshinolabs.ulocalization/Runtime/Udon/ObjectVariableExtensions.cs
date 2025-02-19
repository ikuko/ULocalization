namespace HoshinoLabs.ULocalization.Udon {
    public static class ObjectVariableExtensions {
        public static object GetValue(this ObjectVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid ObjectVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (object)_localization.GetVariable(_variable);
        }

        public static void SetValue(this ObjectVariable self, object value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid ObjectVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetVariable(_variable, value);
        }
    }
}
