#if VRC_SDK_VRCSDK3 && UDONSHARP
using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject.Udon;
using HoshinoLabs.ULocalization.Udon;
#else
using HoshinoLabs.Sardinal;
using HoshinoLabs.Sardinject;
using HoshinoLabs.ULocalization;
#endif
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace HoshinoLabs.ULocalizationSamples.LanguageMenu {
    [AddComponentMenu("")]
#if VRC_SDK_VRCSDK3 && UDONSHARP
    [UdonSharp.UdonBehaviourSyncMode(UdonSharp.BehaviourSyncMode.None)]
    public sealed class LanguageMenu : UdonSharp.UdonSharpBehaviour {
#else
    public sealed class LanguageMenu : MonoBehaviour {
#endif
        [Inject, SerializeField, HideInInspector]
        Localization localization;
        [Inject, SerializeField, HideInInspector]
        TMP_Dropdown dropdown;

#if !COMPILER_UDONSHARP
        [Inject]
        void _() {
            dropdown.options = LocalizationSettings.AvailableLocales.Locales
                .Select(x => new TMP_Dropdown.OptionData(x.ToString()))
                .ToList();
#if VRC_SDK_VRCSDK3 && UDONSHARP && UNITY_EDITOR
            var udon = UdonSharpEditor.UdonSharpEditorUtility.GetBackingUdonBehaviour(this);
            UnityEditor.Events.UnityEventTools.AddStringPersistentListener(dropdown.onValueChanged, udon.SendCustomEvent, nameof(OnValueChanged));
            dropdown.onValueChanged.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.EditorAndRuntime);
#else
            dropdown.onValueChanged.AddListener(_ => OnValueChanged());
#endif
        }
#endif

        public void OnValueChanged() {
            localization.SelectedLocale = localization.AvailableLocales[dropdown.value];
        }

        [Subscriber(typeof(Localization))]
        public void OnLocaleChanged(string locale) {
            var idx = Array.IndexOf(localization.AvailableLocales, locale);
            dropdown.SetValueWithoutNotify(idx);
        }
    }
}
