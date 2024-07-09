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

        public AssetId(T localizedReference) {
            LocalizedReference = localizedReference;
        }
    }

    //[Serializable]
    //public class StringAssetId : AssetId<LocalizedString> { }

    //[Serializable]
    //public class AudioClipAssetId : AssetId<LocalizedAsset<AudioClip>> { }

    //[Serializable]
    //public class TextureAssetId : AssetId<LocalizedAsset<Texture>> { }

    //[Serializable]
    //public class SpriteAssetId : AssetId<LocalizedAsset<Sprite>> { }
}
