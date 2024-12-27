using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject.Udon;
using System;
using System.Globalization;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    internal sealed partial class LocalizationShim : Localization {
        [Inject, SerializeField, HideInInspector]
        string[] _0;
        [Inject, SerializeField, HideInInspector]
        CultureInfo[] _1;
        [Inject, SerializeField, HideInInspector]
        string _2;
        [Inject, SerializeField, HideInInspector]
        CultureInfo _3;
        [Inject, SerializeField, HideInInspector]
        IStartupLocaleSelector[] _4;
        [Inject, SerializeField, HideInInspector]
        object[][] _5;
        [Inject, SerializeField, HideInInspector]
        bool[][] _6;
        [Inject, SerializeField, HideInInspector]
        int _7;
        [Inject, SerializeField, HideInInspector]
        int[] _8;
        [Inject, SerializeField, HideInInspector]
        int[] _9;
        [Inject, SerializeField, HideInInspector]
        string[][] _10;
        [Inject, SerializeField, HideInInspector]
        object[][] _11;
        [Inject, SerializeField, HideInInspector]
        object[][] _12;
        [Inject, SerializeField, HideInInspector]
        DataList[] _13;
        [Inject, SerializeField, HideInInspector]
        int[] _14;
        [Inject, SerializeField, HideInInspector]
        string[] _15;
        [Inject, SerializeField, HideInInspector]
        DataList[] _16;
        [Inject, SerializeField, HideInInspector]
        object[] _17;

        [SerializeField, HideInInspector]
        Signal signal = new Signal<Localization>();

        string locale;
        CultureInfo culture;
        object[] entries;
        bool[] smarts;

        object _l_t;
        object _l_p;
        object _l_a;

        public override string[] AvailableLocales => _0;
        public override string SelectedLocale {
            get => locale;
            set => SetSelectedLocale(value);
        }
        public override string ProjectLocale => _2;

        private void Start() {
            var startupLocale = SelectLocaleUsingStartupSelectors();
            foreach (var startupSelector in _4) {
                DestroyImmediate(startupSelector.gameObject);
            }
            SetSelectedLocale(startupLocale ?? _2);
        }

        void SetSelectedLocale(string locale) {
            if (this.locale == locale) {
                return;
            }
            var idx = Array.IndexOf(_0, locale);
            if (idx < 0) {
                Logger.LogWarning($"Locale {locale} is not supported, ignoring the change.");
                return;
            }
            this.locale = locale;
            culture = _1[idx];
            entries = _5[idx];
            smarts = _6[idx];
            signal.Publish(locale);
            for (var i = 0; i < _7; i++) {
                RefreshLocalizeEvent(i);
            }
        }

        string SelectLocaleUsingStartupSelectors() {
            foreach (var startupSelector in _4) {
                var locale = startupSelector.GetStartupLocale(_0);
                if (locale != null) {
                    return locale;
                }
            }
            return null;
        }

        public int GetLocalized(int localizeEvent) {
            if (localizeEvent < 0) {
                return -1;
            }
            return _8[localizeEvent];
        }

        public void SetLocalized(int localizeEvent, int localized) {
            if (localizeEvent < 0) {
                return;
            }
            var _localized = _8[localizeEvent];
            if (0 <= _localized) {
                _13[_localized].RemoveAll(localizeEvent);
            }
            _8[localizeEvent] = localized;
            if (0 <= localized) {
                _13[localized].Add(localizeEvent);
            }
            RefreshLocalizeEvent(localizeEvent);
        }
        
        public void RefreshLocalizeEvent(int localizeEvent) {
            var localized = _8[localizeEvent];
            if (localized < 0) {
                return;
            }
            var entry = _14[localized];
            if (entry < 0) {
                var __12 = (DataList)_17[localized];
                var __12_count = __12.Count;
                var options = new TMPro.TMP_Dropdown.OptionData[__12_count];
                for (var i = 0; i < __12_count; i++) {
                    var ___12 = (int[])__12[i].Reference;
                    var ___12_0 = ___12[0];
                    var ___12_1 = ___12[1];
                    var text = ___12_0 < 0 ? string.Empty : (string)GetLocalizedValue(___12_0);
                    var image = ___12_1 < 0 ? null : (Sprite)GetLocalizedValue(___12_1);
                    options[i] = new TMPro.TMP_Dropdown.OptionData(text, image);
                }
                _l_p = options;
            }
            else {
                _l_p = GetLocalizedValue(localized);
            }
            var __6_0 = _9[localizeEvent];
            var __6_1 = _10[localizeEvent];
            var __6_2 = _11[localizeEvent];
            var __6_3 = _12[localizeEvent];
            for (var i = 0; i < __6_0; i++) {
                _l_t = __6_2[i];
                _l_a = __6_3[i];
                SendCustomEvent(__6_1[i]);
            }
        }

        public void RefreshLocalized(int localized) {
            var __7_0_1 = _13[localized];
            var __7_0_1_count = __7_0_1.Count;
            for (var i = 0; i < __7_0_1_count; i++) {
                RefreshLocalizeEvent(__7_0_1[i].Int);
            }
        }

        [RecursiveMethod]
        public object GetLocalizedValue(int localized) {
            var entry = _14[localized];
            var value = entries[entry];
            if (smarts[entry]) {
                return SmartLiteFormat((string)value, (DataDictionary)_17[localized]);
            }
            return value;
        }

        public object GetVariable(int variable) {
            return _17[variable];
        }

        public void SetVariable(int variable, object value) {
            _17[variable] = value;
            RefreshVariable(variable);
        }

        public void AddVariable(int variablesGroup, string name, int variable) {
            var __9_3 = _16[variable];
            __9_3.Add(variablesGroup);
            var __12 = (DataDictionary)_17[variablesGroup];
            __12.Add(name, variable);
        }

        public bool RemoveVariable(int variablesGroup, string name) {
            var __12 = (DataDictionary)_17[variablesGroup];
            if (!__12.TryGetValue(name, out var _variable)) {
                return false;
            }
            var r = __12.Remove(name);
            var __9_3 = _16[_variable.Int];
            __9_3.RemoveAll(variablesGroup);
            return r;
        }

        public void AddVariable(int variable, int localizedText, int localizedImage) {
            var __9_3 = _16[localizedText];
            __9_3.Add(variable);
            var __12 = (DataList)_17[variable];
            __12.Add(new DataToken(new[] { localizedText, localizedImage }));
            RefreshLocalized(variable);
        }

        public void RemoveAtVariable(int variable, int index) {
            var __12 = (DataList)_17[variable];
            var localizedText = ((int[])__12[index].Reference)[0];
            __12.RemoveAt(index);
            var __9_3 = _16[localizedText];
            __9_3.RemoveAll(variable);
            RefreshLocalized(variable);
        }

        public void InsertVariable(int variable, int index, int localizedText, int localizedImage) {
            var __9_3 = _16[localizedText];
            __9_3.Add(variable);
            var __12 = (DataList)_17[variable];
            __12.Insert(index, new DataToken(new[] { localizedText, localizedImage }));
            RefreshLocalized(variable);
        }

        public void ClearVariable(int variable) {
            var __12 = (DataList)_17[variable];
            var __12_count = __12.Count;
            for (var i = 0; i < __12_count; i++) {
                var localizedText = ((int[])__12[i].Reference)[0];
                var __9_3 = _16[localizedText];
                __9_3.RemoveAll(variable);
            }
            __12.Clear();
            RefreshLocalized(variable);
        }

        [RecursiveMethod]
        public void RefreshVariable(int variable) {
            if (_13[variable] != null) {
                RefreshLocalized(variable);
            }
            var __9_3 = _16[variable];
            var __9_3_count = __9_3.Count;
            for (var i = 0; i < __9_3_count; i++) {
                RefreshVariable(__9_3[i].Int);
            }
        }
    }
}
