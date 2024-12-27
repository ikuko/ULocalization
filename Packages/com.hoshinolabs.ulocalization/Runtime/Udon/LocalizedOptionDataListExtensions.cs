namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizedOptionDataListExtensions {
        public static void Add(this LocalizedOptionDataList self, LocalizedOptionData option) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            if (option == null) {
                _localization.AddVariable(_localized, -1, -1);
            }
            else {
                var _option = (object[])(object)option;
                var _localizedText = (int)_option[1];
                var _localizedImage = (int)_option[2];
                _localization.AddVariable(_localized, _localizedText, _localizedImage);
            }
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedString text) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _localizedText = text == null ? -1 : (int)((object[])(object)text)[1];
            _localization.AddVariable(_localized, _localizedText, -1);
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _localizedImage = image == null ? -1 : (int)((object[])(object)image)[1];
            _localization.AddVariable(_localized, -1, _localizedImage);
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedString text, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _localizedText = text == null ? -1 : (int)((object[])(object)text)[1];
            var _localizedImage = image == null ? -1 : (int)((object[])(object)image)[1];
            _localization.AddVariable(_localized, _localizedText, _localizedImage);
        }

        public static void RemoveAt(this LocalizedOptionDataList self, int index) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            _localization.RemoveAtVariable(_localized, index);
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedOptionData option) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            if (option == null) {
                _localization.InsertVariable(_localized, index, -1, -1);
            }
            else {
                var _option = (object[])(object)option;
                var _localizedText = (int)_option[1];
                var _localizedImage = (int)_option[2];
                _localization.InsertVariable(_localized, index, _localizedText, _localizedImage);
            }
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedString text) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _localizedText = text == null ? -1 : (int)((object[])(object)text)[1];
            _localization.InsertVariable(_localized, index, _localizedText, -1);
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _localizedImage = image == null ? -1 : (int)((object[])(object)image)[1];
            _localization.InsertVariable(_localized, index, -1, _localizedImage);
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedString text, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _localizedText = text == null ? -1 : (int)((object[])(object)text)[1];
            var _localizedImage = image == null ? -1 : (int)((object[])(object)image)[1];
            _localization.InsertVariable(_localized, index, _localizedText, _localizedImage);
        }

        public static void Clear(this LocalizedOptionDataList self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            _localization.ClearVariable(_localized);
        }
    }
}
