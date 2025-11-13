using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class VariablesGroupAssetExtensions {
        public static bool TryGetValue<T>(this VariablesGroupAsset self, string name, out T value) where T : IVariable {
            if (!self.TryGetValue(name, out var _variable)) {
                value = default;
                return false;
            }
            value = (T)_variable;
            return true;
        }
    }
}
