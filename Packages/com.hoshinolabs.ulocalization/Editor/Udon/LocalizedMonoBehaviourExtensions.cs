using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization.Udon {
    internal static class LocalizedMonoBehaviourExtensions {
        public static bool IsSupported(this LocalizedMonoBehaviour self) {
            switch (self) {
                case UnityEngine.Localization.Components.LocalizeStringEvent:
                case UnityEngine.Localization.Components.LocalizeAudioClipEvent:
                case UnityEngine.Localization.Components.LocalizeTextureEvent:
                case UnityEngine.Localization.Components.LocalizeSpriteEvent:
                case ULocalization.LocalizeDropdownEvent: {
                        return true;
                    }
            }
            return false;
        }
    }
}
