using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization.Udon {
    public static class AssetIdExtensions {
        public static AssetId As<T>(this AssetId<T> self)
            where T : LocalizedReference {
            return (AssetId)(object)self;
        }

        //public static AssetId<T> As<T, V>(this AssetId<V> self)
        //    where T : LocalizedReference
        //    where V : LocalizedReference {
        //    var buff = new object[] { 0 };
        //    return (AssetId<T>)(object)buff;
        //}
    }
}
