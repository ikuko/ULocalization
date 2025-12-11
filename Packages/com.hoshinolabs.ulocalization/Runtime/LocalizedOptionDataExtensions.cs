using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    public static class LocalizedOptionDataExtensions {
        public static LocalizedString GetText(this LocalizedOptionData self) {
            return self.Text;
        }

        public static void SetText(this LocalizedOptionData self, LocalizedString text) {
            self.Text = text;
        }

        public static LocalizedSprite GetImage(this LocalizedOptionData self) {
            return self.Image;
        }

        public static void SetImage(this LocalizedOptionData self, LocalizedSprite image) {
            self.Image = image;
        }
    }
}
