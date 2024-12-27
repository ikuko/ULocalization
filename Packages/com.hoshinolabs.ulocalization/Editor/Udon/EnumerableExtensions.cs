using System;
using System.Collections.Generic;
using System.Linq;
using VRC.SDK3.Data;

namespace HoshinoLabs.ULocalization.Udon {
    internal static class EnumerableExtensions {
        public static DataList ToDataList(this IEnumerable<string> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<object> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<bool> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<sbyte> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<byte> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<short> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<ushort> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<int> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<uint> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<long> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<ulong> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<float> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }
        public static DataList ToDataList(this IEnumerable<double> self) {
            return new DataList(self.Select(x => new DataToken(x)).ToArray());
        }

        public static DataDictionary ToDataDictionary<T>(this IEnumerable<T> self, Func<T, DataToken> keySelector, Func<T, DataToken> elementSelector) {
            var dictionary = new DataDictionary();
            foreach (T item in self) {
                dictionary.Add(keySelector(item), elementSelector(item));
            }
            return dictionary;
        }
    }
}
