using HoshinoLabs.Sardinject.Udon;
using UdonSharp;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [DefaultExecutionOrder(int.MinValue + 1000000)]
    internal sealed class CloneDetector : UdonSharpBehaviour {
        [Inject, SerializeField, HideInInspector]
        Localization localization;

        [Inject, SerializeField, HideInInspector]
        int _0;
        [Inject, SerializeField, HideInInspector]
        object[] _1;

        private void Start() {
            var _localization = (LocalizationShim)localization;
            _localization.RenewPrefab(gameObject, _0, _1);
            DestroyImmediate(this);
        }
    }
}
