using HoshinoLabs.Sardinject;
using HoshinoLabs.ULocalization.Udon;
using UdonSharp;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Samples.Udon {
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
