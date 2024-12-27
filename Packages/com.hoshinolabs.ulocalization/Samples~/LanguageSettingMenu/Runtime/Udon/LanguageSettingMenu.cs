using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject.Udon;
using HoshinoLabs.ULocalization.Udon;
using System;
using System.Linq;
using TMPro;
using UdonSharp;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;

namespace HoshinoLabs.ULocalization.Samples.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class LanguageSettingMenu : UdonSharpBehaviour {
        [Inject, SerializeField, HideInInspector]
        Localization localization;
        [Inject, SerializeField, HideInInspector]
        TMP_Dropdown dropdown;

#if !COMPILER_UDONSHARP && UNITY_EDITOR
        [Inject]
        void InitializeInjection() {
            var availableLocales = LocalizationSettings.AvailableLocales.Locales;
            dropdown.options = availableLocales
                .Select(x => new TMP_Dropdown.OptionData(x.ToString()))
                .ToList();
            var onValueChanged = (UnityEventBase)(object)dropdown.onValueChanged;
            UnityEditor.Events.UnityEventTools.AddPersistentListener(onValueChanged);
            var udon = UdonSharpEditor.UdonSharpEditorUtility.GetBackingUdonBehaviour(this);
            UnityEditor.Events.UnityEventTools.RegisterStringPersistentListener(onValueChanged, 0, udon.SendCustomEvent, nameof(OnValueChanged));
        }
#endif

        public void OnValueChanged() {
            var availableLocales = localization.AvailableLocales;
            localization.SelectedLocale = availableLocales[dropdown.value];
        }

        [Subscriber(typeof(Localization))]
        public void OnLocalizationLocaleChanged(string locale) {
            var availableLocales = localization.AvailableLocales;
            dropdown.SetValueWithoutNotify(Array.IndexOf(availableLocales, locale));
        }
    }
}
