namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizeTextureEventExtensions {
        public static LocalizedTexture GetLocalized(this LocalizeTextureEvent self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizeTextureEvent.");
                return default;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localizeEvent = (int)_self[1];
            var _localized = _localization.GetLocalized(_localizeEvent);
            if (_localized < 0) {
                return default;
            }
            var localized = new object[2];
            localized[0] = _localization;
            localized[1] = _localized;
            return (LocalizedTexture)(object)localized;
        }

        public static void SetLocalized(this LocalizeTextureEvent self, LocalizedTexture localized) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizeTextureEvent.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localizeEvent = (int)_self[1];
            var _localized = localized == null ? -1 : (int)((object[])(object)localized)[1];
            _localization.SetLocalized(_localizeEvent, _localized);
        }
    }
}
