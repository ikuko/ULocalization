using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class LocalizedSprite : Localized, ISerializable {
        [Inject, SerializeField]
        UnityEngine.Localization.LocalizedSprite localized;

        public LocalizedSprite() {

        }

        public LocalizedSprite(UnityEngine.Localization.LocalizedSprite localized) {
            this.localized = localized;
        }

        public void Serialize(IDataWriter writer) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            writer.WriteReference("", LocalizationResolver.Resolve());
            writer.WriteInt32("", LocalizedCache.AddOrGet(localized));
#endif
        }

        public void Deserialize(IDataReader reader) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            reader.SkipEntry();
            reader.SkipEntry();
#endif
        }
    }
}
