using HoshinoLabs.Sardinject;
using UnityEngine;

namespace HoshinoLabs.ULocalizationSamples.VRCClientConnector {
    internal sealed class VRCClientConnectorInstaller : MonoBehaviour, IInstaller {
        public void Install(ContainerBuilder builder) {
#if VRC_SDK_VRCSDK3 && UDONSHARP
            builder.RegisterEntryPoint<Udon.VRCClientConnector>(Lifetime.Cached)
                .UnderTransform(transform);
#endif
        }
    }
}
