using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    public static class NestedVariablesGroupExtensions {
        public static VariablesGroupAsset GetValue(this NestedVariablesGroup self) {
            return self.Value;
        }

        public static void SetValue(this NestedVariablesGroup self, VariablesGroupAsset value) {
            self.Value = value;
        }
    }
}
