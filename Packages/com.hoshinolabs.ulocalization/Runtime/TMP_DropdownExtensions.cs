using System.Linq;
using TMPro;

namespace HoshinoLabs.ULocalization {
    internal static class TMP_DropdownExtensions {
        public static void set_options(this TMP_Dropdown self, TMP_Dropdown.OptionData[] value) {
            var selected = self.value;
            self.ClearOptions();
            self.AddOptions(value.ToList());
            self.SetValueWithoutNotify(selected);
        }
    }
}
