using HoshinoLabs.ULocalization.Udon;
using HoshinoLabs.Sardinject;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    public sealed class TMP_DropdownProxy : MonoBehaviour, IProxyTarget<TMP_Dropdown> {
        [Inject, SerializeField]
        TMP_Dropdown target;

        public Object Target => target;

        [ProxyDeclaringTarget(typeof(TMP_DropdownExtensions))]
        public TMP_Dropdown.OptionData[] options {
            set {
                target.set_options(value);
            }
        }
    }
}
