using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

namespace HoshinoLabs.ULocalization {
    [AddComponentMenu("Localization/Localize Dropdown Event")]
    public class LocalizeDropdownEvent : LocalizedMonoBehaviour {
        [Serializable]
        public class OptionData {
            [SerializeField]
            LocalizedString text = new LocalizedString();
            [SerializeField]
            LocalizedSprite image = new LocalizedSprite();

            public LocalizedString Text {
                get { return text; }
                set { text = value; }
            }

            public LocalizedSprite Image {
                get { return image; }
                set { image = value; }
            }
        }

        [Serializable]
        public class OptionDataList {
            [SerializeField]
            List<OptionData> options;

            public List<OptionData> Options {
                get { return options; }
                set { options = value; }
            }

            public OptionDataList() {
                options = new List<OptionData>();
            }
        }

        [SerializeField]
        OptionDataList options = new OptionDataList();

        public List<OptionData> Options {
            get { return options.Options; }
            set {
                ClearChangeHandler();
                options.Options = value;
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
            EditorApplication.update -= RefreshOptions;
#endif
            var args = options.Options
                .Select(x => {
                    var locale = LocalizationSettings.ProjectLocale;
                    LocalizationSettings.StringDatabase.GetTable(x.Text.TableReference, locale);
                    var text = x.Text.IsEmpty ? null : LocalizationSettings.StringDatabase.GetLocalizedString(x.Text.TableReference, x.Text.TableEntryReference, x.Text.Arguments, locale);
                    var image = x.Image.IsEmpty ? null : LocalizationSettings.AssetDatabase.GetLocalizedAsset<Sprite>(x.Image.TableReference, x.Image.TableEntryReference, locale);
                    return new TMP_Dropdown.OptionData(text, image);
                })
                .ToArray();
            OnUpdateOptions.Invoke(args);
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

#if UNITY_EDITOR
        private void OnValidate() {
            if (!isActiveAndEnabled) {
                return;
            }
            EditorApplication.update += RefreshOptions;
        }
#endif

        void RegisterChangeHandler() {
            foreach (var option in options.Options) {
                if (option.Text != null) {
                    option.Text.StringChanged += UpdateString;
                }
            }
        }

        void ClearChangeHandler() {
            foreach (var option in options.Options) {
                if (option.Text != null) {
                    option.Text.StringChanged -= UpdateString;
                }
            }
        }
    }
}
