using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [BindStartupLocaleSelector(typeof(UnityEngine.Localization.Settings.SystemLocaleSelector))]
    public sealed class SystemLocaleSelector : IStartupLocaleSelector {
        public override string GetStartupLocale(string[] availableLocales) {
            var locale = VRCPlayerApi.GetCurrentLanguage();
            return Array.IndexOf(availableLocales, locale) < 0 ? null : locale;
        }
    }
}
