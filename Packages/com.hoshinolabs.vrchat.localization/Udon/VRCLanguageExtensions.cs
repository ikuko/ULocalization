using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
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
                case "Spanish":
                    return "es";
                case "Italian":
                    return "it";
                case "Korean":
                    return "ko";
                case "German":
                    return "de";
                case "Japanese":
                    return "ja";
                case "Polish":
                    return "pl";
                case "Russian":
                    return "ru";
                case "Portuguese, Brazilian":
                    return "pt-BR";
                case "Chinese Simplified":
                    return "zh-CN";
                case "Chinese Traditional":
                    return "zh-HK";
                case "Toki Pona":// Violation of RFC5646
                    return "tp";
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
                case "tp":// Violation of RFC5646
                    return "Toki Pona";
            }
            return null;
        }
    }
}
