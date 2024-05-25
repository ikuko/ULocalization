using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    public static class LocalizationExtensions {
        public static Locale[] AvailableLocales => LocalizationHelper.AvailableLocales;
    }
}
