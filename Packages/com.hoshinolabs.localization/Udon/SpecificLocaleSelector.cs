using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace HoshinoLabs.Localization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [BindStartupLocaleSelector(typeof(global::UnityEngine.Localization.Settings.SpecificLocaleSelector))]
    public sealed class SpecificLocaleSelector : IStartupLocaleSelector {
#if UNITY_EDITOR
        [BindStartupLocaleSelectorInitializer]
        public static void Initializer(SpecificLocaleSelector self, UnityEngine.Localization.Settings.SpecificLocaleSelector original) {
            self.locale = original.LocaleId.Code;
        }
#endif

        [SerializeField]
        string locale;

        public override string GetStartupLocale(string[] availableLocales) {
            return Array.IndexOf(availableLocales, locale) < 0 ? null : locale;
        }
    }
}
