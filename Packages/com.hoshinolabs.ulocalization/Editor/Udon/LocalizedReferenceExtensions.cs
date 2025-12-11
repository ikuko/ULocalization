using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization.Udon {
    internal static class LocalizedReferenceExtensions {
        public static bool IsSupported(this LocalizedReference self) {
            switch (self) {
                case UnityEngine.Localization.LocalizedString:
                case UnityEngine.Localization.LocalizedAudioClip:
                case UnityEngine.Localization.LocalizedTexture:
                case UnityEngine.Localization.LocalizedSprite:
                case ULocalization.LocalizedOptionData:
                case ULocalization.LocalizedOptionDataList: {
                        return true;
                    }
            }
            return false;
        }
    }
}
