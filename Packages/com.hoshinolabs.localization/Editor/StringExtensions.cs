using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace HoshinoLabs.Localization {
    internal static class StringExtensions {
        static MD5CryptoServiceProvider md5;
        static MD5CryptoServiceProvider Md5 => md5 ?? (md5 = new MD5CryptoServiceProvider());

        public static string ComputeHashMD5(this string self) {
            var buff = Md5.ComputeHash(Encoding.UTF8.GetBytes(self));
            var hash = BitConverter.ToString(buff).ToLower().Replace("-", "");
            return hash;
        }
    }
}
