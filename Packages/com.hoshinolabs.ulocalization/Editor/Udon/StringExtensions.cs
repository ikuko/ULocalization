using System;
using System.Security.Cryptography;
using System.Text;

namespace HoshinoLabs.ULocalization.Udon {
    internal static class StringExtensions {
        readonly static MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();

        public static string ComputeHashMD5(this string self) {
            var buff = md5provider.ComputeHash(Encoding.UTF8.GetBytes(self));
            return BitConverter.ToString(buff).ToLower().Replace("-", string.Empty);
        }
    }
}
