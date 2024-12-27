using TMPro;
using VRC.SDK3.Components;

namespace HoshinoLabs.ULocalization {
    internal static class TMP_DropdownExtensions {
        public static void set_options(this TMP_Dropdown self, TMP_Dropdown.OptionData[] value) {
            var selected = self.value;
            self.ClearOptions();
            self.AddOptions(value);
            self.SetValueWithoutNotify(selected);
        }
    }
}
