using HoshinoLabs.Sardinject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization.Udon {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    public static class VariableCache {
        static Dictionary<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable, HashSet<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable>> variables = new();

        [InitializeOnLoadMethod]
        static void OnLoad() {
            var installersField = typeof(LocalizationInstaller).GetField("Installers", BindingFlags.Static | BindingFlags.NonPublic);
            var installers = (Action<ContainerBuilder>)installersField.GetValue(null);
            installers -= Clear;
            installers += Clear;
            installersField.SetValue(null, installers);
        }

        static void Clear(ContainerBuilder builder) {
            variables.Clear();
        }

        public static int AddOrGet(UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable variable, UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable variablesGroup = default) {
            if (variable == null) {
                return -1;
            }
            if (!variables.ContainsKey(variable)) {
                variables.Add(variable, new());
            }
            variables[variable].Add(variablesGroup);
            return IID.GenerateId(variable);
        }

        public static int AddOrGet<T>(T variablesGroup)
            where T : UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable, IVariableGroup, IDictionary<string, UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable> {
            foreach (var variable in variablesGroup?.Values ?? Enumerable.Empty<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable>()) {
                switch (variable) {
                    case UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup nestedVariablesGroup: {
                            AddOrGet(nestedVariablesGroup);
                            AddOrGet(nestedVariablesGroup, variablesGroup);
                            break;
                        }
                    case UnityEngine.Localization.LocalizedString localizedString: {
                            LocalizedCache.AddOrGet(localizedString);
                            AddOrGet(localizedString, variablesGroup);
                            break;
                        }
                    default: {
                            AddOrGet(variable, variablesGroup);
                            break;
                        }
                }
            }
            return AddOrGet((UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable)variablesGroup);
        }

        public static int AddOrGet(UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup nestedVariablesGroup) {
            AddOrGet(nestedVariablesGroup?.Value);
            AddOrGet(nestedVariablesGroup?.Value, nestedVariablesGroup);
            return AddOrGet((UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable)nestedVariablesGroup);
        }

        public static int AddOrGet(ULocalization.LocalizeDropdownEvent.LocalizedOptionDataList localizedOptionDataList) {
            foreach (var localizedOptionData in localizedOptionDataList ?? Enumerable.Empty<ULocalization.LocalizeDropdownEvent.LocalizedOptionData>()) {
                LocalizedCache.AddOrGet(localizedOptionData?.Text);
                AddOrGet(localizedOptionData?.Text, localizedOptionDataList);
                LocalizedCache.AddOrGet(localizedOptionData?.Image);
            }
            return AddOrGet((UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable)localizedOptionDataList);
        }

        public static IEnumerable<KeyValuePair<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable, HashSet<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable>>> GetAll() {
            return variables;
        }
    }
#endif
}
