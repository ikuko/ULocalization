namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizedOptionDataExtensions {
        public static LocalizedString GetText(this LocalizedOptionData self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionData.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _option = (int[])_localization.GetValue(_localized);
            if (_option[0] < 0) {
                return default;
            }
            var localized = new object[2];
            localized[0] = _localization;
            localized[1] = _option[0];
            return (LocalizedString)(object)localized;
        }

        public static void SetText(this LocalizedOptionData self, LocalizedString text) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionData.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            _localization.SetVariable(_localized, 0, text == null ? -1 : (int)((object[])(object)text)[1]);
        }

        public static LocalizedSprite GetImage(this LocalizedOptionData self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionData.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _option = (int[])_localization.GetValue(_localized);
            if (_option[1] < 0) {
                return default;
            }
            var localized = new object[2];
            localized[0] = _localization;
            localized[1] = _option[1];
            return (LocalizedSprite)(object)localized;
        }

        public static void SetImage(this LocalizedOptionData self, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionData.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            _localization.SetVariable(_localized, 1, image == null ? -1 : (int)((object[])(object)image)[1]);
        }
    }
}
