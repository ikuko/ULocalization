using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizedAudioClipExtensions {
        public static AudioClip LoadAsset(this LocalizedAudioClip self) {
            if (self == null) {
                Logger.LogError("Attempting to use an invalid LocalizedAudioClip.");
                return null;
            }
            var _self = (object[])(object)self;
            var _localization = (LocalizationShim)_self[0];
            var _localized = (int)_self[1];
            return (AudioClip)_localization.GetLocalizedValue(_localized);
        }
    }
}
