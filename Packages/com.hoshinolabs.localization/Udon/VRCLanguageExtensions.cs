using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization.Udon {
    public static class VRCLanguageExtensions {
        /// <summary>
        /// Convert VRChat language to Locale.
        /// The culture name in the format [language]-[region].
        /// The name is a combination of an ISO 639 two-letter lowercase culture code associated with a language and an ISO 3166 two-letter uppercase subculture code associated with a country or region.
        /// </summary>
        /// <param name="language">obtained by VRCPlayerApi.GetCurrentLanguage()</param>
        /// <returns></returns>
        public static string VRCLanguageToLocale(string language) {
            switch (language) {
                case "English":
                    return "en";
                case "French":
                    return "fr";
                case "German":
                    return "de";
                case "Italian":
                    return "it";
                case "Japanese":
                    return "ja";
                case "Korean":
                    return "ko";
                case "Spanish":
                    return "es";
                case "Portuguese":
                    return "pt";
                case "Brazilian":
                    return "br";
                case "Hebrew":
                    return "he";
                case "Polish":
                    return "pl";
                case "Toki Pona":
                    return "tok";
                case "Indonesian":
                    return "id";
                case "Chinese Simplified":
                    return "zh-CN";
                case "Chinese Traditional":
                    return "zh-HK";
                case "Russian":
                    return "ru";
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static string LocaleToVRCLanguage(string locale) {
            switch (locale) {
                case "en":
                    return "English";
                case "fr":
                    return "French";
                case "es":
                    return "Spanish";
                case "it":
                    return "Italian";
                case "ko":
                    return "Korean";
                case "de":
                    return "German";
                case "ja":
                    return "Japanese";
                case "pl":
                    return "Polish";
                case "ru":
                    return "Russian";
                case "pt-BR":
                    return "Portuguese, Brazilian";
                case "zh-CN":
                    return "Chinese Simplified";
                case "zh-HK":
                    return "Chinese Traditional";
                case "tok":
                    return "Toki Pona";
            }
            return null;
        }
    }
}
