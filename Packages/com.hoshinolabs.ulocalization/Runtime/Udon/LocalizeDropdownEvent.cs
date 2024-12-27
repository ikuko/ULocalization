using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class LocalizeDropdownEvent : LocalizeEvent, ISerializable {
        [Inject, SerializeField]
        ULocalization.LocalizeDropdownEvent localizeEvent;

        public LocalizeDropdownEvent() {

        }

        public LocalizeDropdownEvent(ULocalization.LocalizeDropdownEvent localizeEvent) {
            this.localizeEvent = localizeEvent;
        }

        public void Serialize(IDataWriter writer) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            writer.WriteReference("", LocalizationResolver.Resolve());
            writer.WriteInt32("", LocalizeEventCache.AddOrGet(localizeEvent));
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
