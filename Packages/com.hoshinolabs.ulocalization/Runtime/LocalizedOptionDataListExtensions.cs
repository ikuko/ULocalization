using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    public static class LocalizedOptionDataListExtensions {
        public static void Add(this LocalizedOptionDataList self, LocalizedOptionData option) {
            self.Add(option);
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedString text) {
            self.Add(new LocalizedOptionData(text));
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedSprite image) {
            self.Add(new LocalizedOptionData(image));
        }

        public static void Add(this LocalizedOptionDataList self, LocalizedString text, LocalizedSprite image) {
            self.Add(new LocalizedOptionData(text, image));
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedString text) {
            self.Insert(index, new LocalizedOptionData(text));
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedSprite image) {
            self.Insert(index, new LocalizedOptionData(image));
        }

        public static void Insert(this LocalizedOptionDataList self, int index, LocalizedString text, LocalizedSprite image) {
            self.Insert(index, new LocalizedOptionData(text, image));
        }
    }
}
