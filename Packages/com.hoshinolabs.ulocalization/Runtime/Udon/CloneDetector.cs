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
        GameObject _0;
        [Inject, SerializeField, HideInInspector]
        int _1;
        [Inject, SerializeField, HideInInspector]
        object[] _2;

        private void Start() {
            var _localization = (LocalizationShim)localization;
            _localization.RenewPrefab(_0, _1, _2);
            DestroyImmediate(gameObject);
        }
    }
}
