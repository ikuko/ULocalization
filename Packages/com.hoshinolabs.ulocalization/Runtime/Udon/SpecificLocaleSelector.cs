using HoshinoLabs.Sardinject.Udon;
using System;
using UdonSharp;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [BindStartupLocaleSelector(typeof(UnityEngine.Localization.Settings.SpecificLocaleSelector))]
    public sealed class SpecificLocaleSelector : IStartupLocaleSelector {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
        [Inject]
        public void InitializeInjection(UnityEngine.Localization.Settings.SpecificLocaleSelector specificLocaleSelector) {
            locale = specificLocaleSelector.LocaleId.Code;
        }
#endif

        [SerializeField]
        string locale;

        public override string GetStartupLocale(string[] availableLocales) {
            return Array.IndexOf(availableLocales, locale) < 0 ? null : locale;
        }
    }
}
