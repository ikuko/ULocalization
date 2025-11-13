using HoshinoLabs.Sardinject;
using TMPro;
using UnityEngine;

namespace HoshinoLabs.ULocalizationSamples.LanguageMenu {
    internal sealed class LanguageMenuInstaller : MonoBehaviour, IInstaller {
        public void Install(ContainerBuilder builder) {
            builder.RegisterComponentInHierarchy<TMP_Dropdown>()
                .UnderTransform(transform);
            builder.RegisterEntryPoint<LanguageMenu>(Lifetime.Cached)
                .UnderTransform(transform);
#if VRC_SDK_VRCSDK3
            builder.RegisterEntryPoint<VRC.SDK3.Components.VRCUiShape>(Lifetime.Cached)
                .UnderTransform(transform.GetComponentInChildren<Canvas>().transform);
#endif
        }
    }
}
