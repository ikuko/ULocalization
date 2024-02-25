using HoshinoLabs.Sardinject;
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.SDKBase;

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
        // TODO: "onSelectedLocaleChanged" is under consideration for implementation

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
            if(localeId < 0) {
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

        public override void RefreshString(int groupId) {
            var assetId = groups_2[groupId];
            listenerString = currentStringDatabase[assetId];
            var args = groups_3[groupId];
            if (args != null) {
                SmartLiteFormat(args);
            }
            var listenerLength = groups_4_0[groupId];
            listenerHash = groups_4_1[groupId];
            listenerTarget = groups_4_2[groupId];
            listenerArgument = groups_4_3[groupId];
            for (listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                SendCustomEvent(listenerHash[listenerIdx]);
            }
        }

        public override void RefreshAsset(int groupId) {
            var assetId = groups_2[groupId];
            listenerAsset = currentAssetDatabase[assetId];
            var listenerLength = groups_4_0[groupId];
            listenerHash = groups_4_1[groupId];
            listenerTarget = groups_4_2[groupId];
            listenerArgument = groups_4_3[groupId];
            for (listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                SendCustomEvent(listenerHash[listenerIdx]);
            }
        }

        public override string GetLocalizedString(int groupId, string locale) {
            var localeId = Array.IndexOf(availableLocales, locale);
            if (localeId < 0) {
                return null;
            }
            var assetId = groups_2[groupId];
            listenerString = stringDatabase[localeId][assetId];
            var args = groups_3[groupId];
            if (args != null) {
                SmartLiteFormat(args);
            }
            return listenerString;
        }

        public override object GetLocalizedAsset(int groupId, string locale) {
            var localeId = Array.IndexOf(availableLocales, locale);
            var assetId = groups_2[groupId];
            return localeId < 0 ? null : assetDatabase[localeId][assetId];
        }

        void InvokeSelectedLocaleChanged() {
            for (var groupId = 0; groupId < groups_0; groupId++) {
                var assetId = groups_2[groupId];
                if (groups_1[groupId]) {
                    listenerAsset = currentAssetDatabase[assetId];
                }
                else {
                    listenerString = currentStringDatabase[assetId];
                    var args = groups_3[groupId];
                    if (args != null) {
                        SmartLiteFormat(args);
                    }
                }
                var listenerLength = groups_4_0[groupId];
                listenerHash = groups_4_1[groupId];
                listenerTarget = groups_4_2[groupId];
                listenerArgument = groups_4_3[groupId];
                for (listenerIdx = 0; listenerIdx < listenerLength; listenerIdx++) {
                    SendCustomEvent(listenerHash[listenerIdx]);
                }
            }

            // TODO: "onSelectedLocaleChanged" is under consideration for implementation
        }
    }
}
