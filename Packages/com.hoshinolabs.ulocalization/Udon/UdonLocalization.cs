using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject;
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using VRC.SDK3.Data;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    internal partial class UdonLocalization : ILocalization {
        [Inject, SerializeField, HideInInspector]
        IStartupLocaleSelector[] startupSelectors;
        [Inject, SerializeField, HideInInspector]
        string[] availableLocales;
        [Inject, SerializeField, HideInInspector]
        string[][] stringDatabase;
        [Inject, SerializeField, HideInInspector]
        object[][] assetDatabase;
        [Inject, SerializeField, HideInInspector]
        string projectLocale;

        [Inject, SerializeField, HideInInspector]
        ISardinal sardinal;
        [SerializeField, HideInInspector]
        SignalId signalId = new SignalId<ILocalization>();

        public override string[] AvailableLocales => availableLocales;
        public override string ProjectLocale => projectLocale;

        string selectedLocale;

        string[] currentStringDatabase;
        object[] currentAssetDatabase;

        public override string SelectedLocale {
            get => selectedLocale;
            set => SetSelectedLocale(value, true);
        }

        void SetSelectedLocale(string locale, bool invoke) {
            selectedLocale = locale;

            var localeId = Array.IndexOf(availableLocales, locale);
            if (localeId < 0) {
                // Do nothing when an invalid locale is specified
                return;
            }
            currentStringDatabase = stringDatabase[localeId];
            currentAssetDatabase = assetDatabase[localeId];

            if (invoke) {
                InvokeSelectedLocaleChanged();
            }
        }

        string SelectLocaleUsingStartupSelectors() {
            foreach (var startupSelector in startupSelectors) {
                var locale = startupSelector.GetStartupLocale(availableLocales);
                if (locale != null) {
                    return locale;
                }
            }
            return null;
        }

        [Inject, SerializeField, HideInInspector]
        VariableType[] variables_0;
        [Inject, SerializeField, HideInInspector]
        object[] variables_1;

        [Inject, SerializeField, HideInInspector]
        int groups_0;
        [Inject, SerializeField, HideInInspector]
        GroupMode[] groups_1;
        [Inject, SerializeField, HideInInspector]
        int[] groups_2;
        [Inject, SerializeField, HideInInspector]
        DataDictionary[] groups_3;
        [Inject, SerializeField, HideInInspector]
        int[] groups_4_0;
        [Inject, SerializeField, HideInInspector]
        string[][] groups_4_1;
        [Inject, SerializeField, HideInInspector]
        object[][] groups_4_2;
        [Inject, SerializeField, HideInInspector]
        object[][] groups_4_3;

        string listenerString;
        object listenerAsset;
        object listenerTarget;
        object listenerArgument;

        private void Start() {
            SetSelectedLocale(SelectLocaleUsingStartupSelectors(), true);
            foreach (var startupSelector in startupSelectors) {
                DestroyImmediate(startupSelector.gameObject);
            }
            startupSelectors = null;
        }

        public override void Refresh(GroupId id) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            switch (groups_1[groupIdx]) {
                case GroupMode.String: {
                        var assetIdx = groups_2[groupIdx];
                        if (assetIdx < 0) {
                            return;
                        }
                        listenerString = currentStringDatabase[assetIdx];
                        var args = groups_3[groupIdx];
                        if (args != null) {
                            SmartLiteFormat(args);
                        }
                        break;
                    }
                case GroupMode.Asset: {
                        var assetIdx = groups_2[groupIdx];
                        if (assetIdx < 0) {
                            return;
                        }
                        listenerAsset = currentAssetDatabase[assetIdx];
                        break;
                    }
                case GroupMode.Dropdown: {
                        var args = groups_3[groupIdx];
                        var _0 = args[0].Int;
                        var _1 = (int[])args[1].Reference;
                        var _2 = (DataDictionary[])args[2].Reference;
                        var _3 = (int[])args[3].Reference;
                        var options = new TMPro.TMP_Dropdown.OptionData[_0];
                        for (var optionIdx = 0; optionIdx < _0; optionIdx++) {
                            var __1 = _1[optionIdx];
                            if (__1 < 0) {
                                listenerString = null;
                            }
                            else {
                                listenerString = currentStringDatabase[__1];
                                var __2 = _2[optionIdx];
                                if (__2 != null) {
                                    SmartLiteFormat(__2);
                                }
                            }
                            var __3 = _3[optionIdx];
                            if (__3 < 0) {
                                listenerAsset = null;
                            }
                            else {
                                listenerAsset = currentAssetDatabase[__3];
                            }
                            options[optionIdx] = new TMPro.TMP_Dropdown.OptionData(listenerString, (Sprite)listenerAsset);
                        }
                        listenerAsset = options;
                        break;
                    }
            }

            var listenerLength = groups_4_0[groupIdx];
            var listenerHashs = groups_4_1[groupIdx];
            var listenerTargets = groups_4_2[groupIdx];
            var listenerArguments = groups_4_3[groupIdx];
            for (var listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                listenerTarget = listenerTargets[listenerIdx];
                listenerArgument = listenerArguments[listenerIdx];
                SendCustomEvent(listenerHashs[listenerIdx]);
            }
        }

        public override void Refresh(GroupId<LocalizeStringEvent> id) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var assetIdx = groups_2[groupIdx];
            if (assetIdx < 0) {
                return;
            }
            listenerString = currentStringDatabase[assetIdx];
            var args = groups_3[groupIdx];
            if (args != null) {
                SmartLiteFormat(args);
            }

            var listenerLength = groups_4_0[groupIdx];
            var listenerHashs = groups_4_1[groupIdx];
            var listenerTargets = groups_4_2[groupIdx];
            var listenerArguments = groups_4_3[groupIdx];
            for (var listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                listenerTarget = listenerTargets[listenerIdx];
                listenerArgument = listenerArguments[listenerIdx];
                SendCustomEvent(listenerHashs[listenerIdx]);
            }
        }

        public override void Refresh(GroupId<LocalizeDropdownEvent> id) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            var _1 = (int[])args[1].Reference;
            var _2 = (DataDictionary[])args[2].Reference;
            var _3 = (int[])args[3].Reference;
            var options = new TMPro.TMP_Dropdown.OptionData[_0];
            for (var optionIdx = 0; optionIdx < _0; optionIdx++) {
                var __1 = _1[optionIdx];
                if (__1 < 0) {
                    listenerString = null;
                }
                else {
                    listenerString = currentStringDatabase[__1];
                    var __2 = _2[optionIdx];
                    if (__2 != null) {
                        SmartLiteFormat(__2);
                    }
                }
                var __3 = _3[optionIdx];
                if (__3 < 0) {
                    listenerAsset = null;
                }
                else {
                    listenerAsset = currentAssetDatabase[__3];
                }
                options[optionIdx] = new TMPro.TMP_Dropdown.OptionData(listenerString, (Sprite)listenerAsset);
            }
            listenerAsset = options;

            var listenerLength = groups_4_0[groupIdx];
            var listenerHashs = groups_4_1[groupIdx];
            var listenerTargets = groups_4_2[groupIdx];
            var listenerArguments = groups_4_3[groupIdx];
            for (var listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                listenerTarget = listenerTargets[listenerIdx];
                listenerArgument = listenerArguments[listenerIdx];
                SendCustomEvent(listenerHashs[listenerIdx]);
            }
        }

        public override object GetVariable(VariableId id) {
            var variableIdx = (int)((object[])(object)id)[0];
            if (variableIdx < 0) {
                return null;
            }
            return variables_1[variableIdx];
        }

        public override object GetVariable(VariableId<LocalizeStringEvent> id) {
            var variableIdx = (int)((object[])(object)id)[0];
            if (variableIdx < 0) {
                return null;
            }
            return variables_1[variableIdx];
        }

        public override object GetVariable(VariableId<LocalizeDropdownEvent> id) {
            var variableIdx = (int)((object[])(object)id)[0];
            if (variableIdx < 0) {
                return null;
            }
            return variables_1[variableIdx];
        }

        public override void SetVariable(VariableId id, object value) {
            var variableIdx = (int)((object[])(object)id)[0];
            if (variableIdx < 0) {
                return;
            }
            variables_1[variableIdx] = value;
        }

        public override void SetVariable(VariableId<LocalizeStringEvent> id, object value) {
            var variableIdx = (int)((object[])(object)id)[0];
            if (variableIdx < 0) {
                return;
            }
            variables_1[variableIdx] = value;
        }

        public override void SetVariable(VariableId<LocalizeDropdownEvent> id, object value) {
            var variableIdx = (int)((object[])(object)id)[0];
            if (variableIdx < 0) {
                return;
            }
            variables_1[variableIdx] = value;
        }

        public override object GetLocalized(GroupId id, string locale) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return null;
            }
            
            switch (groups_1[groupIdx]) {
                case GroupMode.String: {
                        var assetIdx = groups_2[groupIdx];
                        if (assetIdx < 0) {
                            return null;
                        }
                        listenerString = stringDatabase[localeIdx][assetIdx];
                        var args = groups_3[groupIdx];
                        if (args != null) {
                            SmartLiteFormat(args);
                        }
                        return listenerString;
                    }
                case GroupMode.Asset: {
                        var assetIdx = groups_2[groupIdx];
                        if (assetIdx < 0) {
                            return null;
                        }
                        listenerAsset = assetDatabase[localeIdx][assetIdx];
                        return listenerAsset;
                    }
                case GroupMode.Dropdown: {
                        var args = groups_3[groupIdx];
                        var _0 = args[0].Int;
                        var _1 = (int[])args[1].Reference;
                        var _2 = (DataDictionary[])args[2].Reference;
                        var _3 = (int[])args[3].Reference;
                        var options = new TMPro.TMP_Dropdown.OptionData[_0];
                        for (var optionIdx = 0; optionIdx < _0; optionIdx++) {
                            var __1 = _1[optionIdx];
                            if (__1 < 0) {
                                listenerString = null;
                            }
                            else {
                                listenerString = currentStringDatabase[__1];
                                var __2 = _2[optionIdx];
                                if (__2 != null) {
                                    SmartLiteFormat(__2);
                                }
                            }
                            var __3 = _3[optionIdx];
                            if (__3 < 0) {
                                listenerAsset = null;
                            }
                            else {
                                listenerAsset = currentAssetDatabase[__3];
                            }
                            options[optionIdx] = new TMPro.TMP_Dropdown.OptionData(listenerString, (Sprite)listenerAsset);
                        }
                        listenerAsset = options;
                        return listenerAsset;
                    }
            }

            return null;
        }

        public override string GetLocalized(GroupId<LocalizeStringEvent> id, string locale) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return null;
            }

            var assetIdx = groups_2[groupIdx];
            if (assetIdx < 0) {
                return null;
            }
            listenerString = stringDatabase[localeIdx][assetIdx];
            var args = groups_3[groupIdx];
            if (args != null) {
                SmartLiteFormat(args);
            }
            return listenerString;
        }

        public override object GetLocalized(string locale, AssetId id) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }

            var assetIdx = (int)((object[])(object)id)[0];
            if (assetIdx < 0) {
                return null;
            }
            if (((object[])(object)id).Length == 2) {
                listenerString = stringDatabase[localeIdx][assetIdx];
                var args = (DataDictionary)((object[])(object)id)[1];
                if (args != null) {
                    SmartLiteFormat(args);
                }
                return listenerString;
            }
            else {
                listenerAsset = assetDatabase[localeIdx][assetIdx];
                return listenerAsset;
            }
        }

        public override string GetLocalized(string locale, AssetId<LocalizedString> id) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }

            var assetIdx = (int)((object[])(object)id)[0];
            if (assetIdx < 0) {
                return null;
            }
            listenerString = stringDatabase[localeIdx][assetIdx];
            var args = (DataDictionary)((object[])(object)id)[1];
            if (args != null) {
                SmartLiteFormat(args);
            }
            return listenerString;
        }

        public override void AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString> text) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            args[0] = args[0].Int + 1;
            var _1 = new int[_0 + 1];
            Array.Copy((Array)args[1].Reference, _1, _0);
            _1[_0] = (int)((object[])(object)text)[0];
            args[1] = new DataToken(_1);
            var _2 = new DataDictionary[_0 + 1];
            Array.Copy((Array)args[2].Reference, _2, _0);
            var _args = (DataDictionary)((object[])(object)text)[1];
            _2[_0] = _args == null ? null : _args.ShallowClone();
            args[2] = new DataToken(_2);
            var _3 = new int[_0 + 1];
            Array.Copy((Array)args[3].Reference, _3, _0);
            _3[_0] = -1;
            args[3] = new DataToken(_3);
        }

        public override void AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedAsset<Sprite>> image) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            args[0] = args[0].Int + 1;
            var _1 = new int[_0 + 1];
            Array.Copy((Array)args[1].Reference, _1, _0);
            _1[_0] = -1;
            args[1] = new DataToken(_1);
            var _2 = new DataDictionary[_0 + 1];
            Array.Copy((Array)args[2].Reference, _2, _0);
            _2[_0] = null;
            args[2] = new DataToken(_2);
            var _3 = new int[_0 + 1];
            Array.Copy((Array)args[3].Reference, _3, _0);
            _3[_0] = (int)((object[])(object)image)[0];
            args[3] = new DataToken(_3);
        }

        public override void AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString> text, AssetId<LocalizedAsset<Sprite>> image) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            args[0] = args[0].Int + 1;
            var _1 = new int[_0 + 1];
            Array.Copy((Array)args[1].Reference, _1, _0);
            _1[_0] = (int)((object[])(object)text)[0];
            args[1] = new DataToken(_1);
            var _2 = new DataDictionary[_0 + 1];
            Array.Copy((Array)args[2].Reference, _2, _0);
            var _args = (DataDictionary)((object[])(object)text)[1];
            _2[_0] = _args == null ? null : _args.ShallowClone();
            args[2] = new DataToken(_2);
            var _3 = new int[_0 + 1];
            Array.Copy((Array)args[3].Reference, _3, _0);
            _3[_0] = (int)((object[])(object)image)[0];
            args[3] = new DataToken(_3);
        }

        public override void AddOptions(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString>[] options) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            args[0] = args[0].Int + options.Length;
            var _1 = new int[_0 + options.Length];
            Array.Copy((Array)args[1].Reference, _1, _0);
            for (var optionIdx = 0; optionIdx < options.Length; optionIdx++) {
                _1[_0 + optionIdx] = (int)((object[])(object)options[optionIdx])[0];
            }
            args[1] = new DataToken(_1);
            var _2 = new DataDictionary[_0 + options.Length];
            Array.Copy((Array)args[2].Reference, _2, _0);
            for (var optionIdx = 0; optionIdx < options.Length; optionIdx++) {
                var _args = (DataDictionary)((object[])(object)options[optionIdx])[1];
                _2[_0 + optionIdx] = _args == null ? null : _args.ShallowClone();
            }
            args[2] = new DataToken(_2);
            var _3 = new int[_0 + options.Length];
            Array.Copy((Array)args[3].Reference, _3, _0);
            for (var optionIdx = 0; optionIdx < options.Length; optionIdx++) {
                _3[_0 + optionIdx] = -1;
            }
            args[3] = new DataToken(_3);
        }
        public override void AddOptions(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedAsset<Sprite>>[] options) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            args[0] = args[0].Int + options.Length;
            var _1 = new int[_0 + options.Length];
            Array.Copy((Array)args[1].Reference, _1, _0);
            for (var optionIdx = 0; optionIdx < options.Length; optionIdx++) {
                _1[_0 + optionIdx] = -1;
            }
            args[1] = new DataToken(_1);
            var _2 = new DataDictionary[_0 + options.Length];
            Array.Copy((Array)args[2].Reference, _2, _0);
            for (var optionIdx = 0; optionIdx < options.Length; optionIdx++) {
                _2[_0 + optionIdx] = null;
            }
            args[2] = new DataToken(_2);
            var _3 = new int[_0 + options.Length];
            Array.Copy((Array)args[3].Reference, _3, _0);
            for (var optionIdx = 0; optionIdx < options.Length; optionIdx++) {
                _3[_0 + optionIdx] = (int)((object[])(object)options[optionIdx])[0];
            }
            args[3] = new DataToken(_3);
        }

        public override void AddOptions(GroupId<LocalizeDropdownEvent> id, int length, AssetId<LocalizedString>[] texts, AssetId<LocalizedAsset<Sprite>>[] images) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            var _0 = args[0].Int;
            args[0] = args[0].Int + length;
            var _1 = new int[_0 + length];
            Array.Copy((Array)args[1].Reference, _1, _0);
            for (var optionIdx = 0; optionIdx < length; optionIdx++) {
                _1[_0 + optionIdx] = (int)((object[])(object)texts[optionIdx])[0];
            }
            args[1] = new DataToken(_1);
            var _2 = new DataDictionary[_0 + length];
            Array.Copy((Array)args[2].Reference, _2, _0);
            for (var optionIdx = 0; optionIdx < length; optionIdx++) {
                var _args = (DataDictionary)((object[])(object)texts[optionIdx])[1];
                _2[_0 + optionIdx] = _args == null ? null : _args.ShallowClone();
            }
            args[2] = new DataToken(_2);
            var _3 = new int[_0 + length];
            Array.Copy((Array)args[3].Reference, _3, _0);
            for (var optionIdx = 0; optionIdx < length; optionIdx++) {
                _3[_0 + optionIdx] = (int)((object[])(object)images[optionIdx])[0];
            }
            args[3] = new DataToken(_3);
        }

        public override void ClearOptions(GroupId<LocalizeDropdownEvent> id) {
            var groupIdx = (int)((object[])(object)id)[0];
            if (groupIdx < 0) {
                return;
            }

            var args = groups_3[groupIdx];
            args[0] = 0;
            args[1] = new DataToken(new int[0]);
            args[2] = new DataToken(new DataDictionary[0]);
            args[3] = new DataToken(new int[0]);
        }

        void InvokeSelectedLocaleChanged() {
            for (var groupIdx = 0; groupIdx < groups_0; groupIdx++) {
                switch (groups_1[groupIdx]) {
                    case GroupMode.String: {
                            var assetIdx = groups_2[groupIdx];
                            if (assetIdx < 0) {
                                continue;
                            }
                            listenerString = currentStringDatabase[assetIdx];
                            var args = groups_3[groupIdx];
                            if (args != null) {
                                SmartLiteFormat(args);
                            }
                            break;
                        }
                    case GroupMode.Asset: {
                            var assetIdx = groups_2[groupIdx];
                            if (assetIdx < 0) {
                                continue;
                            }
                            listenerAsset = currentAssetDatabase[assetIdx];
                            break;
                        }
                    case GroupMode.Dropdown: {
                            var args = groups_3[groupIdx];
                            var _0 = args[0].Int;
                            var _1 = (int[])args[1].Reference;
                            var _2 = (DataDictionary[])args[2].Reference;
                            var _3 = (int[])args[3].Reference;
                            var options = new TMPro.TMP_Dropdown.OptionData[_0];
                            for (var optionIdx = 0; optionIdx < _0; optionIdx++) {
                                var __1 = _1[optionIdx];
                                if (__1 < 0) {
                                    listenerString = null;
                                }
                                else {
                                    listenerString = currentStringDatabase[__1];
                                    var __2 = _2[optionIdx];
                                    if (__2 != null) {
                                        SmartLiteFormat(__2);
                                    }
                                }
                                var __3 = _3[optionIdx];
                                if (__3 < 0) {
                                    listenerAsset = null;
                                }
                                else {
                                    listenerAsset = currentAssetDatabase[__3];
                                }
                                options[optionIdx] = new TMPro.TMP_Dropdown.OptionData(listenerString, (Sprite)listenerAsset);
                            }
                            listenerAsset = options;
                            break;
                        }
                }
                var listenerLength = groups_4_0[groupIdx];
                var listenerHashs = groups_4_1[groupIdx];
                var listenerTargets = groups_4_2[groupIdx];
                var listenerArguments = groups_4_3[groupIdx];
                for (var listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                    listenerTarget = listenerTargets[listenerIdx];
                    listenerArgument = listenerArguments[listenerIdx];
                    SendCustomEvent(listenerHashs[listenerIdx]);
                }
            }

            // publish selected locale changed
            sardinal.Publish(signalId, selectedLocale);
        }
    }
}
