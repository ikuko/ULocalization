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
            var _variable = (int)((object[])(object)option)[1];
            _localization.AddVariable(_localized, _variable);
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedString text) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = _localization.NewLocalized("__843847da481d19ec55c1ea6e32ddff8f");
            _localization.SetValue(_variable, new[] { -1, -1 });
            _localization.SetVariable(_variable, 0, (int)((object[])(object)text)[1]);
            _localization.AddVariable(_localized, _variable);
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = _localization.NewLocalized("__843847da481d19ec55c1ea6e32ddff8f");
            _localization.SetValue(_variable, new[] { -1, -1 });
            _localization.SetVariable(_variable, 1, (int)((object[])(object)image)[1]);
            _localization.AddVariable(_localized, _variable);
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedString text, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = _localization.NewLocalized("__843847da481d19ec55c1ea6e32ddff8f");
            _localization.SetValue(_variable, new[] { -1, -1 });
            _localization.SetVariable(_variable, 0, (int)((object[])(object)text)[1]);
            _localization.SetVariable(_variable, 1, (int)((object[])(object)image)[1]);
            _localization.AddVariable(_localized, _variable);
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
            var _variable = (int)((object[])(object)option)[1];
            _localization.InsertVariable(_localized, index, _variable);
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedString text) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = _localization.NewLocalized("__843847da481d19ec55c1ea6e32ddff8f");
            _localization.SetValue(_variable, new[] { -1, -1 });
            _localization.SetVariable(_variable, 0, (int)((object[])(object)text)[1]);
            _localization.InsertVariable(_localized, index, _variable);
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = _localization.NewLocalized("__843847da481d19ec55c1ea6e32ddff8f");
            _localization.SetValue(_variable, new[] { -1, -1 });
            _localization.SetVariable(_variable, 1, (int)((object[])(object)image)[1]);
            _localization.InsertVariable(_localized, index, _variable);
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedString text, LocalizedSprite image) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedOptionDataList.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = _localization.NewLocalized("__843847da481d19ec55c1ea6e32ddff8f");
            _localization.SetValue(_variable, new[] { -1, -1 });
            _localization.SetVariable(_variable, 0, (int)((object[])(object)text)[1]);
            _localization.SetVariable(_variable, 1, (int)((object[])(object)image)[1]);
            _localization.InsertVariable(_localized, index, _variable);
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
