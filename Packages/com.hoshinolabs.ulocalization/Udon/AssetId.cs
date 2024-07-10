using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public class AssetId<T> where T : LocalizedReference {
        [SerializeField]
        public T LocalizedReference;

        public AssetId() {

        }
    }

    [Serializable]
    public class AssetId : AssetId<LocalizedReference> {
        internal AssetId() {

        }
    }
}
