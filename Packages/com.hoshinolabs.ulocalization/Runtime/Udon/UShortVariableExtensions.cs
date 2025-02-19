namespace HoshinoLabs.ULocalization.Udon {
    public static class UShortVariableExtensions {
        public static ushort GetValue(this UShortVariable self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid UShortVariable.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            return (ushort)_localization.GetVariable(_variable);
        }

        public static void SetValue(this UShortVariable self, ushort value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid UShortVariable.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variable = (int)_self[1];
            _localization.SetVariable(_variable, value);
        }
    }
}
