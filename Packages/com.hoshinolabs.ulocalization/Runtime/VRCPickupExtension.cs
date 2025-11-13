using HoshinoLabs.Sardinject;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
#if VRC_SDK_VRCSDK3
    public sealed class VRCPickupExtension : MonoBehaviour, IBehaviourExtension<VRC.SDK3.Components.VRCPickup> {
#else
    public sealed class VRCPickupExtension : MonoBehaviour {
#endif
#if VRC_SDK_VRCSDK3
        [Inject, SerializeField]
        VRC.SDK3.Components.VRCPickup target;
#endif

#if VRC_SDK_VRCSDK3
        public Object Target => target;
#else
        public Object Target => null;
#endif

        public string InteractionText {
#if VRC_SDK_VRCSDK3
            get => target.InteractionText;
            set => target.InteractionText = value;
#else
            get { return null; }
            set { var _ = value; }
#endif
        }

        public string UseText {
#if VRC_SDK_VRCSDK3
            get => target.UseText;
            set => target.UseText = value;
#else
            get { return null; }
            set { var _ = value; }
#endif
        }
    }
}
