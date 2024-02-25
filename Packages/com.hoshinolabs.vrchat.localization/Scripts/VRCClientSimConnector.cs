using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using HoshinoLabs.Localization.Udon;
using HoshinoLabs.Sardinject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UdonSharpEditor;
using UnityEditor;
#endif
using UnityEngine;
using VRC.SDK3.ClientSim;
#if UNITY_EDITOR
using VRC.SDK3.ClientSim.Editor;
#endif
using VRC.Udon;

namespace HoshinoLabs.Localization {
    public sealed class VRCClientSimConnector : MonoBehaviour {
        [Inject]
        ILocalization localization;

        private async void Start() {
            var cancellationToken = this.GetCancellationTokenOnDestroy();

#if UNITY_EDITOR
            var udon = UdonSharpEditorUtility.GetBackingUdonBehaviour(localization);
            var field = typeof(UdonBehaviour).GetField("_hasDoneStart", BindingFlags.Instance | BindingFlags.NonPublic);
            await UniTask.WaitUntilValueChanged(this, x => (bool)field.GetValue(udon), cancellationToken: cancellationToken);
#endif

            Dispatch();
        }

        void Dispatch() {
            var cancellationToken = this.GetCancellationTokenOnDestroy();

            UniTaskAsyncEnumerable.EveryValueChanged(this, _ => localization.SelectedLocale)
                .Select(x => VRCLanguageExtensions.LocaleToVRCLanguage(localization.SelectedLocale))
                .Where(x => x != ClientSimSettings.Instance.currentLanguage)
                .Where(x => 0 <= Array.IndexOf(ClientSimSettings.Instance.availableLanguages, x))
                .ForEachAsync(x => {
                    ClientSimSettings.Instance.currentLanguage = x;
#if UNITY_EDITOR
                    if (EditorWindow.HasOpenInstances<ClientSimSettingsWindow>()) {
                        var window = EditorWindow.GetWindow<ClientSimSettingsWindow>();
                        var field = typeof(ClientSimSettingsWindow).GetField("selectedLanguageIndex", BindingFlags.Instance | BindingFlags.NonPublic);
                        field.SetValue(window, Array.IndexOf(ClientSimSettings.Instance.availableLanguages, x));
                    }
#endif
                }, cancellationToken);
            UniTaskAsyncEnumerable.EveryValueChanged(this, _ => ClientSimSettings.Instance.currentLanguage)
                .Select(x => VRCLanguageExtensions.VRCLanguageToLocale(x))
                .Where(x => x != localization.SelectedLocale)
                .ForEachAsync(x => {
                    localization.SelectedLocale = x;
                }, cancellationToken);
        }
    }
}
