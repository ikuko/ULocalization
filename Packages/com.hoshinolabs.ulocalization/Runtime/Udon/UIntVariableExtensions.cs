namespace HoshinoLabs.ULocalization.Udon {
    public static class UIntVariableExtensions {
        public static uint GetValue(this UIntVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid UIntVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (uint)_localization.GetValue(_variable);
        }

        public static void SetValue(this UIntVariable self, uint value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid UIntVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetValue(_variable, value);
        }
    }
}
