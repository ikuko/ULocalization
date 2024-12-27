using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizedTextureExtensions {
        public static Texture LoadAsset(this LocalizedTexture self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedTexture.");
                return null;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            return (Texture)_localization.GetLocalizedValue(_localized);
        }
    }
}
