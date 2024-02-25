using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace HoshinoLabs.Localization {
    public struct Locale {
        string name;
        string code;
        CultureInfo cultureInfo;

        public string Name => name;
        public string Code => code;
        public CultureInfo CultureInfo => cultureInfo;

        internal Locale(string name, string code, CultureInfo cultureInfo) {
            this.name = name;
            this.code = code;
            this.cultureInfo = cultureInfo;
        }
    }
}
