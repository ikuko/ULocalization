using HoshinoLabs.Sardinject.Udon;
using HoshinoLabs.ULocalization.Udon;
using UdonSharp;
using UnityEngine;

namespace HoshinoLabs.ULocalizationSamples.VRCClientConnector.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class VRCClientConnector : UdonSharpBehaviour {
        [Inject, SerializeField, HideInInspector]
        Localization localization;

        public override void OnLanguageChanged(string language) {
            localization.SelectedLocale = language;
        }
    }
}
