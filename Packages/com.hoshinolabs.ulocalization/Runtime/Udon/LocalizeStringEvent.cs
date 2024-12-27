using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class LocalizeStringEvent : LocalizeEvent, ISerializable {
        [Inject, SerializeField]
        UnityEngine.Localization.Components.LocalizeStringEvent localizeEvent;

        public LocalizeStringEvent() {

        }

        public LocalizeStringEvent(UnityEngine.Localization.Components.LocalizeStringEvent localizeEvent) {
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
