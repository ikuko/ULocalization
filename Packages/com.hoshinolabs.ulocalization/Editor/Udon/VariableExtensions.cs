namespace HoshinoLabs.ULocalization.Udon {
    internal static class VariableExtensions {
        public static bool IsSupported(this UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable self) {
            switch (self) {
                case UnityEngine.Localization.SmartFormat.PersistentVariables.BoolVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.SByteVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ByteVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ShortVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.UShortVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.IntVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.UIntVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.LongVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ULongVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.StringVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.FloatVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.DoubleVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ObjectVariable:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup:
                case UnityEngine.Localization.SmartFormat.PersistentVariables.VariablesGroupAsset:
                case UnityEngine.Localization.LocalizedString:
                case ULocalization.LocalizedOptionData:
                case ULocalization.LocalizedOptionDataList: {
                        return true;
                    }
            }
            return false;
        }
    }
}
