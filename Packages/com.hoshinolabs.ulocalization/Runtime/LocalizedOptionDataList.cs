using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.ULocalization {
    [Serializable]
    public sealed class LocalizedOptionDataList : LocalizedReference, IList<LocalizedOptionData>, IVariableGroup, IVariable, IDisposable {
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
                    var locale = LocalizationSettings.SelectedLocale ?? LocalizationSettings.ProjectLocale;
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

        public bool TryGetValue(string key, out IVariable value) {
            if (int.TryParse(key, out var index)) {
                value = options[index];
                return true;
            }

            value = default;
            return false;
        }

        void IDisposable.Dispose() {
            GC.SuppressFinalize(this);
        }
    }
}
