using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    public sealed class Locale : IEquatable<Locale> {
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

        internal Locale(CultureInfo cultureInfo) {
            this.name = cultureInfo.EnglishName;
            this.code = cultureInfo.Name;
            this.cultureInfo = cultureInfo;
        }

        public bool Equals(Locale other) {
            return other != null && name == other.name && code == other.code;
        }

        public override string ToString() {
            return $"{name} ({code})";
        }
    }
}
