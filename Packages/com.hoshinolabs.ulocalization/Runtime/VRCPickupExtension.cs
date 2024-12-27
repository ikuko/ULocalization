using HoshinoLabs.Sardinject;
using UnityEngine;
using VRC.SDK3.Components;

namespace HoshinoLabs.ULocalization {
    public sealed class VRCPickupExtension : MonoBehaviour, IBehaviourExtension<VRCPickup> {
        [Inject, SerializeField]
        VRCPickup target;

        public Object Target => target;

        public string InteractionText {
            get => target.InteractionText;
            set => target.InteractionText = value;
        }

        public string UseText {
            get => target.UseText;
            set => target.UseText = value;
        }
    }
}
