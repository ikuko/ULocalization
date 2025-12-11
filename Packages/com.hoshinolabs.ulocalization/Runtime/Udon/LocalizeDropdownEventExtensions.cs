namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizeDropdownEventExtensions {
        public static void RefreshOptions(this LocalizeDropdownEvent self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizeDropdownEvent.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localizeEvent = (int)_self[1];
            _localization.RefreshLocalizeEvent(_localizeEvent);
        }

        public static LocalizedOptionDataList GetOptions(this LocalizeDropdownEvent self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizeDropdownEvent.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localizeEvent = (int)_self[1];
            var _localized = _localization.GetLocalized(_localizeEvent);
            if (_localized < 0) {
                return default;
            }
            var options = new object[2];
            options[0] = _localization;
            options[1] = _localized;
            return (LocalizedOptionDataList)(object)options;
        }

        public static void SetOptions(this LocalizeDropdownEvent self, LocalizedOptionDataList options) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizeDropdownEvent.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localizeEvent = (int)_self[1];
            var _localized = options == null ? -1 : (int)((object[])(object)options)[1];
            _localization.SetLocalized(_localizeEvent, _localized);
        }
    }
}
