using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
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
            var args = options.Options
                .Select(x => {
                    var text = x.Text.IsEmpty ? "" : x.Text.GetLocalizedString();
                    return new TMP_Dropdown.OptionData(text);
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

        private void OnValidate() {
            RefreshOptions();
        }

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
