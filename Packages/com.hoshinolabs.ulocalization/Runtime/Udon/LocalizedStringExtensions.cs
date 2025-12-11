using VRC.SDK3.Data;

namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizedStringExtensions {
        public static void RefreshString(this LocalizedString self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            _localization.RefreshVariable(_localized);
        }

        public static string GetLocalizedString(this LocalizedString self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                return null;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            return (string)_localization.GetLocalizedValue(_localized);
        }

        public static bool TryGetValue(this LocalizedString self, string name, out IVariable value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                value = default;
                return false;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                value = default;
                return false;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var variables = (DataDictionary)_localization.GetValue(_localized);
            if (!variables.TryGetValue(name, out var _variable)) {
                value = default;
                return false;
            }
            var variable = new object[2];
            variable[0] = _localization;
            variable[1] = _variable.Int;
            value = (IVariable)(object)variable;
            return true;
        }

        public static bool TryGetValue<T>(this LocalizedString self, string name, out T value) where T : IVariable {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                value = default;
                return false;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                value = default;
                return false;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var variables = (DataDictionary)_localization.GetValue(_localized);
            if (!variables.TryGetValue(name, out var _variable)) {
                value = default;
                return false;
            }
            var variable = new object[2];
            variable[0] = _localization;
            variable[1] = _variable.Int;
            value = (T)(object)variable;
            return true;
        }

        public static void Add(this LocalizedString self, string name, IVariable variable) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                return;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                return;
            }
            if (variable == null) {
                Logger.LogError("Variable is null.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = (int)((object[])(object)variable)[1];
            _localization.AddVariable(_localized, name, _variable);
        }

        public static void Add<T>(this LocalizedString self, string name, T variable) where T : IVariable {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                return;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                return;
            }
            if (variable == null) {
                Logger.LogError("Variable is null.");
                return;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var _variable = (int)((object[])(object)variable)[1];
            _localization.AddVariable(_localized, name, _variable);
        }

        public static bool Remove(this LocalizedString self, string name) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                return false;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                return false;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            return _localization.RemoveVariable(_localized, name);
        }

        public static bool ContainsKey(this LocalizedString self, string name) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedString.");
                return false;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                return false;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            var variables = (DataDictionary)_localization.GetValue(_localized);
            return variables.ContainsKey(name);
        }
    }
}
