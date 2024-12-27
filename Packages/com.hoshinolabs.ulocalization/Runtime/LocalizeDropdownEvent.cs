using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    [AddComponentMenu("Localization/Localize Dropdown Event")]
    public sealed class LocalizeDropdownEvent : LocalizedMonoBehaviour {
        [Serializable]
        public sealed class LocalizedOptionData {
            event ChangeHandler changeHandler;

            public delegate void ChangeHandler();

            public event ChangeHandler OptionChanged {
                add {
                    if (value == null) {
                        throw new ArgumentNullException();
                    }
                    changeHandler += value;
                }
                remove {
                    changeHandler -= value;
                }
            }

            [SerializeField]
            LocalizedString text = new();
            [SerializeField]
            LocalizedSprite image = new();

            public LocalizedString Text {
                get => text;
                set {
                    ClearChangeHandler();
                    text = value;
                    RegisterChangeHandler();
                }
            }

            public LocalizedSprite Image {
                get => image;
                set {
                    ClearChangeHandler();
                    image = value;
                    RegisterChangeHandler();
                }
            }

            public LocalizedOptionData() {

            }

            public LocalizedOptionData(LocalizedString text) {
                this.text = text;
            }

            public LocalizedOptionData(LocalizedSprite image) {
                this.image = image;
            }

            public LocalizedOptionData(LocalizedString text, LocalizedSprite image) {
                this.text = text;
                this.image = image;
            }

            void UpdateString(string value) {
                changeHandler?.Invoke();
            }

            void UpdateAsset(Sprite value) {
                changeHandler?.Invoke();
            }

            void RegisterChangeHandler() {
                if (text != null) {
                    text.StringChanged += UpdateString;
                }
                if (image != null) {
                    image.AssetChanged += UpdateAsset;
                }
            }

            void ClearChangeHandler() {
                if (text != null) {
                    text.StringChanged -= UpdateString;
                }
                if (image != null) {
                    image.AssetChanged -= UpdateAsset;
                }
            }
        }

        [Serializable]
        public sealed class LocalizedOptionDataList : LocalizedReference, IList<LocalizedOptionData>, IVariable, IDisposable {
            event ChangeHandler changeHandler;

            public delegate void ChangeHandler();

            public event ChangeHandler OptionsChanged {
                add {
                    if (value == null) {
                        throw new ArgumentNullException();
                    }
                    changeHandler += value;
                }
                remove {
                    changeHandler -= value;
                }
            }

            [SerializeField]
            List<LocalizedOptionData> options = new();

            public List<LocalizedOptionData> Options {
                get => options;
                set {
                    ClearChangeHandler();
                    options = value;
                    RegisterChangeHandler();
                }
            }

            public int Count => options.Count;

            public bool IsReadOnly => false;

            public LocalizedOptionData this[int index] {
                get => options[index];
                set {
                    ClearChangeHandler();
                    options[index] = value;
                    RegisterChangeHandler();
                }
            }

            public TMP_Dropdown.OptionData[] GetLocalizedOptionData() {
                return options
                    .Select(x => {
                        var locale = LocalizationSettings.ProjectLocale;
                        LocalizationSettings.StringDatabase.GetTable(x.Text.TableReference, locale);
                        var text = x.Text.IsEmpty ? null : LocalizationSettings.StringDatabase.GetLocalizedString(x.Text.TableReference, x.Text.TableEntryReference, x.Text.Arguments, locale);
                        var image = x.Image.IsEmpty ? null : LocalizationSettings.AssetDatabase.GetLocalizedAsset<Sprite>(x.Image.TableReference, x.Image.TableEntryReference, locale);
                        return new TMP_Dropdown.OptionData(text, image);
                    })
                    .ToArray();
            }

            public int IndexOf(LocalizedOptionData item) {
                return options.IndexOf(item);
            }

            public void Insert(int index, LocalizedOptionData item) {
                ClearChangeHandler();
                options.Insert(index, item);
                RegisterChangeHandler();
            }

            public void RemoveAt(int index) {
                ClearChangeHandler();
                options.RemoveAt(index);
                RegisterChangeHandler();
            }

            public void Add(LocalizedOptionData item) {
                ClearChangeHandler();
                options.Add(item);
                RegisterChangeHandler();
            }

            public void Clear() {
                ClearChangeHandler();
                options.Clear();
                RegisterChangeHandler();
            }

            public bool Contains(LocalizedOptionData item) {
                return options.Contains(item);
            }

            public void CopyTo(LocalizedOptionData[] array, int arrayIndex) {
                options.CopyTo(array, arrayIndex);
            }

            public bool Remove(LocalizedOptionData item) {
                ClearChangeHandler();
                var result = options.Remove(item);
                RegisterChangeHandler();
                return result;
            }

            public IEnumerator<LocalizedOptionData> GetEnumerator() {
                return options.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return options.GetEnumerator();
            }

            protected override void ForceUpdate() {

            }

            protected override void Reset() {

            }

            void UpdateOption() {
                changeHandler?.Invoke();
            }

            void RegisterChangeHandler() {
                foreach (var option in options) {
                    option.OptionChanged += UpdateOption;
                }
            }

            void ClearChangeHandler() {
                foreach (var option in options) {
                    option.OptionChanged -= UpdateOption;
                }
            }

            public object GetSourceValue(ISelectorInfo selector) {
                return options;
            }

            void IDisposable.Dispose() {
                GC.SuppressFinalize(this);
            }
        }

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
