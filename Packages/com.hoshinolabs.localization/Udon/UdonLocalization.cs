using HoshinoLabs.Sardinal;
using HoshinoLabs.Sardinal.Udon;
using HoshinoLabs.Sardinject;
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace HoshinoLabs.Localization.Udon {
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
        ISignalHub signal;
        [Inject, SignalId(typeof(LocalizationSignal)), SerializeField, HideInInspector]
        object signalId;

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
        bool[] groups_1;
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
        string[] listenerHash;
        object[] listenerTarget;
        object[] listenerArgument;
        int listenerIdx;

        private void Start() {
            SetSelectedLocale(SelectLocaleUsingStartupSelectors(), true);
            foreach (var startupSelector in startupSelectors) {
                DestroyImmediate(startupSelector.gameObject);
            }
            startupSelectors = null;
        }

        public override void RefreshString(object groupId) {
            var groupIdx = (int)groupId;
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
            listenerHash = groups_4_1[groupIdx];
            listenerTarget = groups_4_2[groupIdx];
            listenerArgument = groups_4_3[groupIdx];
            for (listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                SendCustomEvent(listenerHash[listenerIdx]);
            }
        }

        public override object GetVariable(object variableId) {
            var variableIdx = (int)variableId;
            return variables_1[variableIdx];
        }

        public override void SetVariable(object variableId, object value) {
            var variableIdx = (int)variableId;
            variables_1[variableIdx] = value;
        }

        public override void RefreshAsset(object groupId) {
            var groupIdx = (int)groupId;
            var assetIdx = groups_2[groupIdx];
            if (assetIdx < 0) {
                return;
            }
            listenerAsset = currentAssetDatabase[assetIdx];
            var listenerLength = groups_4_0[groupIdx];
            listenerHash = groups_4_1[groupIdx];
            listenerTarget = groups_4_2[groupIdx];
            listenerArgument = groups_4_3[groupIdx];
            for (listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                SendCustomEvent(listenerHash[listenerIdx]);
            }
        }

        public override string GetLocalizedString(object groupId, string locale) {
            var localeIdx = Array.IndexOf(availableLocales, locale);
            if (localeIdx < 0) {
                return null;
            }
            var groupIdx = (int)groupId;
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
            var assetIdx = groups_2[groupIdx];
            if (assetIdx < 0) {
                return null;
            }
            listenerAsset = assetDatabase[localeIdx][assetIdx];
            return listenerAsset;
        }

        void InvokeSelectedLocaleChanged() {
            for (var groupIdx = 0; groupIdx < groups_0; groupIdx++) {
                var assetIdx = groups_2[groupIdx];
                if (assetIdx < 0) {
                    continue;
                }
                if (groups_1[groupIdx]) {
                    listenerAsset = currentAssetDatabase[assetIdx];
                }
                else {
                    listenerString = currentStringDatabase[assetIdx];
                    var args = groups_3[groupIdx];
                    if (args != null) {
                        SmartLiteFormat(args);
                    }
                }
                var listenerLength = groups_4_0[groupIdx];
                listenerHash = groups_4_1[groupIdx];
                listenerTarget = groups_4_2[groupIdx];
                listenerArgument = groups_4_3[groupIdx];
                for (listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                    SendCustomEvent(listenerHash[listenerIdx]);
                }
            }

            // publish selected locale changed
            signal.Publish(signalId, selectedLocale);
        }
    }
}
