using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace HoshinoLabs.Localization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [BindStartupLocaleSelector(typeof(global::UnityEngine.Localization.Settings.SystemLocaleSelector))]
    public sealed class SystemLocaleSelector : IStartupLocaleSelector {
        public override string GetStartupLocale(string[] availableLocales) {
#if UNITY_EDITOR
            var locale = VRCLanguageExtensions.VRCLanguageToLocale(VRCPlayerApi.GetCurrentLanguage());
#else
            var locale = VRCPlayerApi.GetCurrentLanguage();
#endif
            return Array.IndexOf(availableLocales, locale) < 0 ? null : locale;
        }
    }
}
