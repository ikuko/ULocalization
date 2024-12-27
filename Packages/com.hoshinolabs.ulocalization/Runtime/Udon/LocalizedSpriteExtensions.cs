using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizedSpriteExtensions {
        public static Sprite LoadAsset(this LocalizedSprite self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedSprite.");
                return null;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            return (Sprite)_localization.GetLocalizedValue(_localized);
        }
    }
}
