namespace HoshinoLabs.ULocalization.Udon {
    public static class NestedVariablesGroupExtensions {
        public static VariablesGroupAsset GetValue(this NestedVariablesGroup self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid NestedVariablesGroup.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variablesGroup = (int)_self[1];
            if (_variablesGroup < 0) {
                return default;
            }
            var variable = new object[2];
            variable[0] = _localization;
            variable[1] = (int)_localization.GetValue(_variablesGroup);
            return (VariablesGroupAsset)(object)variable;
        }

        public static void SetValue(this NestedVariablesGroup self, VariablesGroupAsset value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid NestedVariablesGroup.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            var _variablesGroup = value == null ? -1 : (int)((object[])(object)value)[1];
            _localization.SetValue(_variable, _variablesGroup);
        }
    }
}
