using HoshinoLabs.Sardinject;
using HoshinoLabs.ULocalization.Samples.Udon;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Samples {
    public class VRCClientConnectorInstaller : MonoBehaviour, IInstaller {
        public void Install(ContainerBuilder builder) {
            builder.RegisterEntryPoint<VRCClientConnector>(Lifetime.Cached)
                .UnderTransform(transform);
        }
    }
}
