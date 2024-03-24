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
                case "English":// com.vrchat.worlds >= 3.5.1
                    return "en";
                case "French":// com.vrchat.worlds >= 3.5.1
                    return "fr";
                case "German":// com.vrchat.worlds >= 3.5.1
                    return "de";
                case "Italian":// com.vrchat.worlds >= 3.5.1
                    return "it";
                case "Japanese":// com.vrchat.worlds >= 3.5.1
                    return "ja";
                case "Korean":// com.vrchat.worlds >= 3.5.1
                    return "ko";
                case "Spanish":// com.vrchat.worlds >= 3.5.1
                    return "es";
                case "Portuguese":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "pt";
                case "Brazilian":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "br";
                case "Hebrew":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "he";
                case "Polish":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "pl";
                case "Toki Pona":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "tp";
                case "Indonesian":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "id";
                case "Chinese Simplified":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "zh-CN";
                case "Chinese Traditional":// com.vrchat.worlds >= 3.5.2-beta.1
                    return "zh-HK";
                case "Russian":// com.vrchat.worlds >= 3.5.2-beta.1
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
                    return "English";// vrchat >= 2024.1.1p2-1407
                case "fr":
                    return "French";// vrchat >= 2024.1.1p2-1407
                case "es":
                    return "Spanish";// vrchat >= 2024.1.1p2-1407
                case "it":
                    return "Italian";// vrchat >= 2024.1.1p2-1407
                case "ko":
                    return "Korean";// vrchat >= 2024.1.1p2-1407
                case "de":
                    return "German";// vrchat >= 2024.1.1p2-1407
                case "ja":
                    return "Japanese";// vrchat >= 2024.1.1p2-1407
                case "pl":
                    return "Polish";// vrchat >= 2024.1.1p2-1407
                case "ru":
                    return "Russian";// vrchat >= 2024.1.1p2-1407
                case "pt-BR":
                    return "Portuguese, Brazilian";// vrchat >= 2024.1.1p2-1407
                case "zh-CN":
                    return "Chinese Simplified";// vrchat >= 2024.1.1p2-1407
                case "zh-HK":
                    return "Chinese Traditional";// vrchat >= 2024.1.1p2-1407
            }
            return null;
        }
    }
}
