using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

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
            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode) {
                return;
            }
#endif

            var translatedOptions = options
                .Select(x => {
                    if (x == null) {
                        return new TMP_Dropdown.OptionData(null, null);
                    }
                    var locale = LocalizationSettings.SelectedLocale ?? LocalizationSettings.ProjectLocale;
                    var text = x.Text == null || x.Text.IsEmpty ? null : LocalizationSettings.StringDatabase.GetLocalizedStringAsync(x.Text.TableReference, x.Text.TableEntryReference, x.Text.Arguments, locale, x.Text.FallbackState, x.Text.Count > 0 ? x.Text : null).WaitForCompletion();
                    var image = x.Image == null || x.Image.IsEmpty ? null : LocalizationSettings.AssetDatabase.GetLocalizedAsset<Sprite>(x.Image.TableReference, x.Image.TableEntryReference, locale);
                    return new TMP_Dropdown.OptionData(text, image);
                })
                .ToArray();
            updateOptions?.Invoke(translatedOptions);
        }

        private void OnEnable() {
            RegisterChangeHandler();
        }

        private void OnDisable() {
            ClearChangeHandler();
        }

#if UNITY_EDITOR
        private void OnValidate() {
            UnityEditor.EditorApplication.update += RefreshOptions;
        }
#endif

        void RegisterChangeHandler() {
            options.OptionsChanged += RefreshOptions;
        }

        void ClearChangeHandler() {
            options.OptionsChanged -= RefreshOptions;
        }
    }
}
