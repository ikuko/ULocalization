namespace HoshinoLabs.ULocalization {
    public static class LocalizeDropdownEventExtensions {
        public static LocalizedOptionDataList GetOptions(this LocalizeDropdownEvent self) {
            return self.Options;
        }

        public static void SetOptions(this LocalizeDropdownEvent self, LocalizedOptionDataList options) {
            self.Options = options;
        }
    }
}
