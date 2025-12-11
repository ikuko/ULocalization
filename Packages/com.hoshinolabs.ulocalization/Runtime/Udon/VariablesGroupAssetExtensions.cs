using VRC.SDK3.Data;

namespace HoshinoLabs.ULocalization.Udon {
    public static class VariablesGroupAssetExtensions {
        public static bool TryGetValue(this VariablesGroupAsset self, string name, out IVariable value) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid VariablesGroupAsset.");
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
            var _variablesGroup = (int)_self[1];
            var variables = (DataDictionary)_localization.GetValue(_variablesGroup);
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

        public static bool TryGetValue<T>(this VariablesGroupAsset self, string name, out T value) where T : IVariable {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid VariablesGroupAsset.");
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
            var _variablesGroup = (int)_self[1];
            var variables = (DataDictionary)_localization.GetValue(_variablesGroup);
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

        public static void Add(this VariablesGroupAsset self, string name, IVariable variable) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid VariablesGroupAsset.");
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
            var _variablesGroup = (int)_self[1];
            var _variable = (int)((object[])(object)variable)[1];
            _localization.AddVariable(_variablesGroup, name, _variable);
        }

        public static void Add<T>(this VariablesGroupAsset self, string name, T variable) where T : IVariable {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid VariablesGroupAsset.");
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
            var _variablesGroup = (int)_self[1];
            var _variable = (int)((object[])(object)variable)[1];
            _localization.AddVariable(_variablesGroup, name, _variable);
        }

        public static bool Remove(this VariablesGroupAsset self, string name) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid VariablesGroupAsset.");
                return false;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                return false;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variablesGroup = (int)_self[1];
            return _localization.RemoveVariable(_variablesGroup, name);
        }

        public static bool ContainsKey(this VariablesGroupAsset self, string name) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid VariablesGroupAsset.");
                return false;
            }
            if (string.IsNullOrEmpty(name)) {
                Logger.LogError("Name is empty.");
                return false;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _variablesGroup = (int)_self[1];
            var variables = (DataDictionary)_localization.GetValue(_variablesGroup);
            return variables.ContainsKey(name);
        }
    }
}
