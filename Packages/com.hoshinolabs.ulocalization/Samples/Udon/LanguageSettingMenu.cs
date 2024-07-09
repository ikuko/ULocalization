using HoshinoLabs.ULocalization.Udon;
using HoshinoLabs.Sardinject;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace HoshinoLabs.ULocalization.Samples.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class LanguageSettingMenu : UdonSharpBehaviour {
        [Inject, SerializeField, HideInInspector]
        ILocalization localization;

        Dropdown dropdown;
        string[] availableLocales;

        private void Start() {
            dropdown = GetComponentInChildren<Dropdown>();
            availableLocales = localization.AvailableLocales;
        }

        public void OnValueChanged() {
            var value = dropdown.value;
            if (value < 0 || availableLocales.Length <= value) {
                return;
            }
            localization.SelectedLocale = availableLocales[value];
        }
    }
}
