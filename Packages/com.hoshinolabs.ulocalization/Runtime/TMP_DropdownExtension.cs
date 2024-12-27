using HoshinoLabs.Sardinject;
using TMPro;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    public sealed class TMP_DropdownExtension : MonoBehaviour, IBehaviourExtension<TMP_Dropdown> {
        [Inject, SerializeField]
        TMP_Dropdown target;

        public Object Target => target;

        [BehaviourExtensionDeclaring(typeof(HoshinoLabs.ULocalization.TMP_DropdownExtensions))]
        public TMP_Dropdown.OptionData[] options {
            set {
                target.set_options(value);
            }
        }
    }
}
