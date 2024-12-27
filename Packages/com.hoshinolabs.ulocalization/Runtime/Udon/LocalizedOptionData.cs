using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class LocalizedOptionData : Localized, ISerializable {
        [Inject, SerializeField]
        ULocalization.LocalizeDropdownEvent.LocalizedOptionData localized;

        public LocalizedOptionData() {

        }

        public LocalizedOptionData(ULocalization.LocalizeDropdownEvent.LocalizedOptionData localized) {
            this.localized = localized;
        }

        public void Serialize(IDataWriter writer) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            writer.WriteReference("", LocalizationResolver.Resolve());
            writer.WriteInt32("", LocalizedCache.AddOrGet(localized.Text));
            writer.WriteInt32("", LocalizedCache.AddOrGet(localized.Image));
#endif
        }

        public void Deserialize(IDataReader reader) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            reader.SkipEntry();
            reader.SkipEntry();
            reader.SkipEntry();
#endif
        }
    }
}
