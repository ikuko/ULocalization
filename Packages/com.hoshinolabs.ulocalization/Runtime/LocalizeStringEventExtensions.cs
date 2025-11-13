using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    public static class LocalizeStringEventExtensions {
        public static LocalizedString GetLocalized(this LocalizeStringEvent self) {
            return self.StringReference;
        }

        public static void SetLocalized(this LocalizeStringEvent self, LocalizedString localized) {
            self.StringReference = localized;
        }
    }
}
