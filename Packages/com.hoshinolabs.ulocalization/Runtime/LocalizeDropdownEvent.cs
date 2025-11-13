using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    [AddComponentMenu("Localization/Localize Dropdown Event")]
    public sealed class LocalizeDropdownEvent : LocalizedMonoBehaviour {
        [SerializeField]
        LocalizedOptionDataList options = new();

        public LocalizedOptionDataList Options {
            get { return options; }
            set {
                ClearChangeHandler();
                options = value;
                if (isActiveAndEnabled) {
                    RegisterChangeHandler();
                }
            }
        }

        [SerializeField]
        UnityEvent<TMP_Dropdown.OptionData[]> updateOptions = new UnityEvent<TMP_Dropdown.OptionData[]>();

        public UnityEvent<TMP_Dropdown.OptionData[]> OnUpdateOptions {
            get => updateOptions;
            set => updateOptions = value;
        }

        public void RefreshOptions() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.update -= RefreshOptions;
#endif
            var translatedOptions = options.GetLocalizedOptionData();
            updateOptions?.Invoke(translatedOptions);
        }

        private void OnEnable() {
            RegisterChangeHandler();
        }

        private void OnDisable() {
            ClearChangeHandler();
        }

        void UpdateString(string value) {
            RefreshOptions();
        }

        void UpdateAsset(Sprite value) {
            RefreshOptions();
        }

#if UNITY_EDITOR
        private void OnValidate() {
            if (!isActiveAndEnabled) {
                return;
            }
            UnityEditor.EditorApplication.update += RefreshOptions;
        }
#endif

        void RegisterChangeHandler() {
            foreach (var option in options.Options) {
                if (option.Text != null) {
                    option.Text.StringChanged += UpdateString;
                }
                if (option.Image != null) {
                    option.Image.AssetChanged += UpdateAsset;
                }
            }
        }

        void ClearChangeHandler() {
            foreach (var option in options.Options) {
                if (option.Text != null) {
                    option.Text.StringChanged -= UpdateString;
                }
                if (option.Image != null) {
                    option.Image.AssetChanged -= UpdateAsset;
                }
            }
        }
    }
}
