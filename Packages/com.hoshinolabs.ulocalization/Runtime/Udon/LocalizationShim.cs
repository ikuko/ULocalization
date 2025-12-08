using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject.Udon;
using System;
using System.Globalization;
using UdonSharp;
using UdonSharp.Lib.Internal;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.Udon;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [DefaultExecutionOrder(-1000)]
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
        int _13;
        [Inject, SerializeField, HideInInspector]
        DataList[] _14;
        [Inject, SerializeField, HideInInspector]
        int[] _15;
        [Inject, SerializeField, HideInInspector]
        int _16;
        [Inject, SerializeField, HideInInspector]
        string[] _17;
        [Inject, SerializeField, HideInInspector]
        DataList[] _18;
        [Inject, SerializeField, HideInInspector]
        object[] _19;
        [Inject, SerializeField, HideInInspector]
        object[][] _20;
        [Inject, SerializeField, HideInInspector]
        int[][] _21;
        [Inject, SerializeField, HideInInspector]
        string[] _22;
        [Inject, SerializeField, HideInInspector]
        int[] _23;
        [Inject, SerializeField, HideInInspector]
        string[][] _24;
        [Inject, SerializeField, HideInInspector]
        string[][] _25;

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
                if (locale == null) {
                    continue;
                }
                return locale;
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
                _14[_localized].RemoveAll(localizeEvent);
            }
            _8[localizeEvent] = localized;
            if (0 <= localized) {
                _14[localized].Add(localizeEvent);
            }
            RefreshLocalizeEvent(localizeEvent);
        }

        public void RefreshLocalizeEvent(int localizeEvent) {
            if (localizeEvent < 0) {
                return;
            }
            var localized = _8[localizeEvent];
            if (localized < 0) {
                return;
            }
            var __14 = _15[localized];
            if (__14 < 0) {
                var __17 = (DataList)_19[localized];
                var __17_count = __17.Count;
                var options = new TMPro.TMP_Dropdown.OptionData[__17_count];
                for (var i = 0; i < __17_count; i++) {
                    var ___17 = (int[])__17[i].Reference;
                    var ___17_0 = ___17[0];
                    var ___17_1 = ___17[1];
                    var text = ___17_0 < 0 ? string.Empty : (string)GetLocalizedValue(___17_0);
                    var image = ___17_1 < 0 ? null : (Sprite)GetLocalizedValue(___17_1);
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
            var __13 = _14[localized];
            var __13_count = __13.Count;
            for (var i = 0; i < __13_count; i++) {
                RefreshLocalizeEvent(__13[i].Int);
            }
        }

        [RecursiveMethod]
        public object GetLocalizedValue(int localized) {
            var entry = _15[localized];
            if (entry < 0) {
                return null;
            }
            var value = entries[entry];
            if (smarts[entry]) {
                return SmartLiteFormat((string)value, (DataDictionary)_19[localized]);
            }
            return value;
        }

        public object GetVariable(int variable) {
            return _19[variable];
        }

        public void SetVariable(int variable, object value) {
            _19[variable] = value;
            RefreshVariable(variable);
        }

        public void AddVariable(int variablesGroup, string name, int variable) {
            var __16 = _18[variable];
            __16.Add(variablesGroup);
            var __17 = (DataDictionary)_19[variablesGroup];
            __17.Add(name, variable);
        }

        public bool RemoveVariable(int variablesGroup, string name) {
            var __17 = (DataDictionary)_19[variablesGroup];
            if (!__17.TryGetValue(name, out var _variable)) {
                return false;
            }
            var r = __17.Remove(name);
            var __16 = _18[_variable.Int];
            __16.RemoveAll(variablesGroup);
            return r;
        }

        public void AddVariable(int variable, int localizedText, int localizedImage) {
            var __16 = _18[localizedText];
            __16.Add(variable);
            var __17 = (DataList)_19[variable];
            __17.Add(new DataToken(new[] { localizedText, localizedImage }));
        }

        public void RemoveAtVariable(int variable, int index) {
            var __17 = (DataList)_19[variable];
            var localizedText = ((int[])__17[index].Reference)[0];
            __17.RemoveAt(index);
            var __16 = _18[localizedText];
            __16.RemoveAll(variable);
        }

        public void InsertVariable(int variable, int index, int localizedText, int localizedImage) {
            var __16 = _18[localizedText];
            __16.Add(variable);
            var __17 = (DataList)_19[variable];
            __17.Insert(index, new DataToken(new[] { localizedText, localizedImage }));
        }

        public void ClearVariable(int variable) {
            var __17 = (DataList)_19[variable];
            var __17_count = __17.Count;
            for (var i = 0; i < __17_count; i++) {
                var localizedText = ((int[])__17[i].Reference)[0];
                var __16 = _18[localizedText];
                __16.RemoveAll(variable);
            }
            __17.Clear();
        }

        [RecursiveMethod]
        public void RefreshVariable(int variable) {
            if (_14[variable] != null) {
                RefreshLocalized(variable);
            }
            var __16 = _18[variable];
            var __16_count = __16.Count;
            for (var i = 0; i < __16_count; i++) {
                RefreshVariable(__16[i].Int);
            }
        }

        DataDictionary _r_cache0;
        DataDictionary _r_cache1;
        object[] _r_refs0;
        object[] _r_refs1;

        public void RenewPrefab(GameObject go, int prefab, object[] refs) {
            _r_cache0 = new DataDictionary();
            _r_cache1 = new DataDictionary();
            _r_refs0 = _20[prefab];
            _r_refs1 = refs;
            var __19 = _21[prefab];
            var udons = go.GetComponentsInChildren<UdonBehaviour>(true);
            for (var i = 0; i < udons.Length; i++) {
                var instance = udons[i];

#if UNITY_EDITOR
                if (instance.GetProgramVariableType(CompilerConstants.UsbTypeIDHeapKey) == null) {
                    return;
                }
#endif
                var value = instance.GetProgramVariable(CompilerConstants.UsbTypeNameHeapKey);
                if (value == null) {
                    return;
                }

                var id = (string)value;
                var idx = Array.IndexOf(_22, id);
                if (idx < 0) {
                    return;
                }

                var __21 = _23[idx];
                var __22 = _24[idx];
                var __23 = _25[idx];
                for (var j = 0; j < __21; j++) {
                    var _v = (object[])instance.GetProgramVariable(__22[j]);
                    switch (__23[j]) {
                        case "__34e35fe8fc0d5c82f904f6ad75d8a5f6":
                        case "__8d96e78ca3b3e1527053aa36651e286b":
                        case "__79d2bc6f06db2986192a496ab93261bf":
                        case "__b6e214ef954e55f0fec2f7458bb876e7":
                        case "__f812cfe152444a1eb84b0dc7d7a968c2": {
                                if (Array.IndexOf(__19, (int)_v[1]) < 0) {
                                    continue;
                                }
                                _v[1] = CloneLocalizeEvent((int)_v[1]);
                                break;
                            }
                        case "__8a40d06f0f1ef4f691875d86a3c4c58c":
                        case "__c0eea7769cdfe536c00e9f21b4511726":
                        case "__a7d514cbdeb678df58989ae027cd00ea":
                        case "__45e14183d1316ab8c4a4c59000a0cb64": {
                                _v[1] = CloneLocalized((int)_v[1]);
                                break;
                            }
                        case "__843847da481d19ec55c1ea6e32ddff8f": {
                                _v[1] = CloneLocalized((int)_v[1]);
                                _v[2] = CloneLocalized((int)_v[2]);
                                break;
                            }
                        case "__461b2df608253952f317044024ef8027": {
                                _v[1] = CloneLocalized((int)_v[1]);
                                break;
                            }
                        case "__f8cfba77af0119c086592e79c73223e5":
                        case "__6bac394d6972c8d339cc1ce54df77912":
                        case "__7e161907af17a8f682d768188abd5951":
                        case "__87ef78382d22f90afacdd86d7c2c3e65":
                        case "__e2c64e0a94ccfc78d9209d4d9aaffce7":
                        case "__8417c01a3ee51184c42f97c8f6e41b4a":
                        case "__9843bf736c4a3f95db46565832dc7167":
                        case "__261e9c8a98d5bc34284778a40dbcf076":
                        case "__012ee6846df47c4946e18c2d71a61ca1":
                        case "__2e798db3630c1fd3c89877775b600ffe":
                        case "__73eb38c4d216f0260fa5dd939499ea3b":
                        case "__7a160556cb5c2de9039d3b53bdde58a7":
                        case "__d3be8ac28dfa83b00c677fa0937010c8":
                        case "__6c640a4ed53d954835db21cc931dc34e":
                        case "__6e28290f07397f02ad85d3e9d4494ccc": {
                                _v[1] = CloneVariable((int)_v[1]);
                                break;
                            }
                    }
                }
            }
        }

        int CloneLocalizeEvent(int localizeEvent) {
            if (localizeEvent < 0) {
                return -1;
            }

            if (_r_cache0.TryGetValue(localizeEvent, out var cache)) {
                return cache.Int;
            }

            var _localized = CloneLocalized(_8[localizeEvent]);
            var _localizeEvent = _7;

            var __7 = _localizeEvent + 1;

            var __8 = new int[__7];
            Array.Copy(_8, __8, _7);
            __8[_localizeEvent] = _8[localizeEvent];
            _8 = __8;
            var __9 = new int[__7];
            Array.Copy(_9, __9, _7);
            var ___9 = _9[localizeEvent];
            __9[_localizeEvent] = ___9;
            _9 = __9;
            var __10 = new string[__7][];
            Array.Copy(_10, __10, _7);
            var ___10 = new string[___9];
            Array.Copy(_10[localizeEvent], ___10, ___9);
            __10[_localizeEvent] = ___10;
            _10 = __10;
            var __11 = new object[__7][];
            Array.Copy(_11, __11, _7);
            var ___11 = new object[___9];
            Array.Copy(_11[localizeEvent], ___11, ___9);
            for (var i = 0; i < ___9; i++) {
                var idx = Array.IndexOf(_r_refs0, ___11[i]);
                if (idx < 0) {
                    continue;
                }
                ___11[i] = _r_refs1[idx];
            }
            __11[_localizeEvent] = ___11;
            _11 = __11;

            var __12 = new object[__7][];
            Array.Copy(_12, __12, _7);
            var ___12 = new object[___9];
            Array.Copy(_12[localizeEvent], ___12, ___9);
            for (var i = 0; i < ___9; i++) {
                var idx = Array.IndexOf(_r_refs0, ___12[i]);
                if (idx < 0) {
                    continue;
                }
                ___12[i] = _r_refs1[idx];
            }
            __12[_localizeEvent] = ___12;
            _12 = __12;

            _7 = __7;

            _14[_localized].RemoveAll(localizeEvent);
            _8[_localizeEvent] = _localized;
            _14[_localized].Add(_localizeEvent);

            _r_cache0.Add(localizeEvent, _localizeEvent);

            return _localizeEvent;
        }

        [RecursiveMethod]
        int CloneLocalized(int localized) {
            if (localized < 0) {
                return -1;
            }

            if (_r_cache1.TryGetValue(localized, out var cache)) {
                return cache.Int;
            }

            var _variable = CloneVariable(localized);
            var _localized = _variable;

            if (_14[localized] == null) {
                return _localized;
            }

            var __13 = _localized + 1;

            var __14 = new DataList[__13];
            Array.Copy(_14, __14, _13);
            __14[_localized] = _14[localized].DeepClone();
            _14 = __14;
            var __15 = new int[__13];
            Array.Copy(_15, __15, _13);
            __15[_localized] = _15[localized];
            _15 = __15;

            _13 = __13;

            return _localized;
        }

        [RecursiveMethod]
        int CloneVariable(int variable) {
            if (variable < 0) {
                return -1;
            }

            switch (_17[variable]) {
                case "__8a40d06f0f1ef4f691875d86a3c4c58c": {
                        var __19 = ((DataDictionary)_19[variable]).DeepClone();
                        var __19_count = __19.Count;
                        var __19_ks = __19.GetKeys();
                        for (var i = 0; i < __19_count; i++) {
                            var __19_k = __19_ks[i];
                            var __19_v = __19[__19_k];
                            __19[__19_k] = CloneLocalized(__19_v.Int);
                        }
                        var _variable = CloneVariable(variable, __19);
                        for (var i = 0; i < __19_count; i++) {
                            var __19_k = __19_ks[i];
                            var __19_v = __19[__19_k];
                            _18[__19_v.Int].Add(_variable);
                        }
                        return _variable;
                    }
                case "__461b2df608253952f317044024ef8027": {
                        var __19 = ((DataList)_19[variable]).DeepClone();
                        var __19_count = __19.Count;
                        for (var i = 0; i < __19_count; i++) {
                            var ___19 = (int[])((int[])__19[i].Reference).Clone();
                            ___19[0] = CloneLocalized(___19[0]);
                            ___19[1] = CloneLocalized(___19[1]);
                            __19[i] = new DataToken(___19);
                        }
                        return CloneVariable(variable, __19);
                    }
                case "__d3be8ac28dfa83b00c677fa0937010c8": {
                        var __19 = _19[variable];
                        var idx = Array.IndexOf(_r_refs0, __19);
                        return CloneVariable(variable, idx < 0 ? __19 : _r_refs1[idx]);
                    }
            }

            return CloneVariable(variable, _19[variable]);
        }

        int CloneVariable(int variable, object value) {
            if (_r_cache1.TryGetValue(variable, out var cache)) {
                return cache.Int;
            }

            var _variable = _16;

            var __16 = _16 + 1;

            var __17 = new string[__16];
            Array.Copy(_17, __17, _16);
            __17[_variable] = _17[variable];
            _17 = __17;
            var __18 = new DataList[__16];
            Array.Copy(_18, __18, _16);
            __18[_variable] = new DataList();
            _18 = __18;
            var __19 = new object[__16];
            Array.Copy(_19, __19, _16);
            __19[_variable] = value;
            _19 = __19;

            _16 = __16;

            _r_cache1.Add(variable, _variable);

            return _variable;
        }
    }
}
