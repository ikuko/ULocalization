using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using HoshinoLabs.Localization.Udon;
using HoshinoLabs.Sardinject;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UdonSharpEditor;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using VRC.Udon;

namespace HoshinoLabs.Localization {
    public sealed class UnityLocalizationConnector : MonoBehaviour {
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
                .Where(x => x != LocalizationSettings.SelectedLocale.Identifier.Code)
                .Select(x => LocalizationSettings.AvailableLocales.GetLocale(x) ?? Locale.CreateLocale(x))
                .ForEachAsync(x => {
                    LocalizationSettings.SelectedLocale = x;
                }, cancellationToken);
            UniTaskAsyncEnumerable.EveryValueChanged(this, _ => LocalizationSettings.SelectedLocale.Identifier.Code)
                .Where(x => x != localization.SelectedLocale)
                .ForEachAsync(x => {
                    localization.SelectedLocale = x;
                }, cancellationToken);
        }
    }
}
