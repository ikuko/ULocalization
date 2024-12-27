using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class LocalizedTexture : Localized, ISerializable {
        [Inject, SerializeField]
        UnityEngine.Localization.LocalizedTexture localized;

        public LocalizedTexture() {

        }

        public LocalizedTexture(UnityEngine.Localization.LocalizedTexture localized) {
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
