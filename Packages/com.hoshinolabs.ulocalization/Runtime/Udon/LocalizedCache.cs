using HoshinoLabs.Sardinject;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization.Udon {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    public static class LocalizedCache {
        static Dictionary<LocalizedReference, HashSet<LocalizedMonoBehaviour>> localizeds = new();

        [InitializeOnLoadMethod]
        static void OnLoad() {
            var installersField = typeof(LocalizationInstaller).GetField("Installers", BindingFlags.Static | BindingFlags.NonPublic);
            var installers = (Action<ContainerBuilder>)installersField.GetValue(null);
            installers -= Clear;
            installers += Clear;
            installersField.SetValue(null, installers);
        }

        static void Clear(ContainerBuilder builder) {
            localizeds.Clear();
        }

        public static int AddOrGet(LocalizedReference localized, LocalizedMonoBehaviour localizeEvent = default) {
            if (localized == null) {
                return -1;
            }
            if (!localizeds.ContainsKey(localized)) {
                localizeds.Add(localized, new());
            }
            localizeds[localized].Add(localizeEvent);
            return IID.GenerateId(localized);
        }

        public static int AddOrGet<T>(T localized, LocalizedMonoBehaviour localizeEvent = default)
            where T : LocalizedReference, UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable, IVariableGroup, IDictionary<string, UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable> {
            VariableCache.AddOrGet(localized);
            return AddOrGet((LocalizedReference)localized, localizeEvent);
        }

        public static int AddOrGet(ULocalization.LocalizedOptionDataList localized, LocalizedMonoBehaviour localizeEvent = default) {
            VariableCache.AddOrGet(localized);
            return AddOrGet((LocalizedReference)localized, localizeEvent);
        }

        public static IEnumerable<KeyValuePair<LocalizedReference, HashSet<LocalizedMonoBehaviour>>> GetAll() {
            return localizeds;
        }
    }
#endif
}
