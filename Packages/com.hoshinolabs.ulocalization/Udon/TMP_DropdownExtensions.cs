using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VRC.SDK3.Components;

namespace HoshinoLabs.ULocalization.Udon {
    public static class TMP_DropdownExtensions {
        public static void set_options(this TMP_Dropdown self, TMP_Dropdown.OptionData[] value) {
            self.ClearOptions();
            self.AddOptions(value);
        }
    }
}
