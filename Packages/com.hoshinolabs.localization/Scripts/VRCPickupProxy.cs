using HoshinoLabs.Sardinject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Components;

namespace HoshinoLabs.Localization {
    public sealed class VRCPickupProxy : MonoBehaviour, IProxyTarget<VRCPickup> {
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
