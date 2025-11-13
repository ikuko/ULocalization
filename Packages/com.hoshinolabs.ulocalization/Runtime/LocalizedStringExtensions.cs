using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class LocalizedStringExtensions {
        public static bool TryGetValue<T>(this LocalizedString self, string name, out T value) where T : IVariable {
            if (!self.TryGetValue(name, out var _variable)) {
                value = default;
                return false;
            }
            value = (T)_variable;
            return true;
        }
    }
}
