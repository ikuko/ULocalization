using HoshinoLabs.Sardinal;
using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject;
using System;
using UdonSharp;
using UnityEngine;
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

        public override void RefreshString(object groupId) {
            var groupIdx = (int)groupId;
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

        public override void RefreshAsset(object groupId) {
            var groupIdx = (int)groupId;
            if (groupIdx < 0) {
                return;
            }
            var assetIdx = groups_2[groupIdx];
            if (assetIdx < 0) {
                return;
            }
            listenerAsset = currentAssetDatabase[assetIdx];
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

        public override object GetVariable(object variableId) {
            var variableIdx = (int)variableId;
            if (variableIdx < 0) {
                return null;
            }
            return variables_1[variableIdx];
        }

        public override void SetVariable(object variableId, object value) {
            var variableIdx = (int)variableId;
            if (variableIdx < 0) {
                return;
            }
            variables_1[variableIdx] = value;
        }

        public override string GetLocalizedString(object groupId, string locale) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }
            var groupIdx = (int)groupId;
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

        public override object GetLocalizedAsset(object groupId, string locale) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }
            var groupIdx = (int)groupId;
            if (groupIdx < 0) {
                return null;
            }
            var assetIdx = groups_2[groupIdx];
            if (assetIdx < 0) {
                return null;
            }
            listenerAsset = assetDatabase[localeIdx][assetIdx];
            return listenerAsset;
        }

        public override string GetLocalizedString(string locale, object assetId) {
            return null;
        }

        public override object GetLocalizedAsset(string locale, object assetId) {
            return null;
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
