using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization.Udon {
    public static class GroupIdExtensions {
        public static GroupId As<T>(this GroupId<T> self)
            where T : LocalizedMonoBehaviour {
            return (GroupId)(object)self;
        }

        //public static GroupId<T> As<T, V>(this GroupId<V> self)
        //    where T : LocalizedMonoBehaviour
        //    where V : LocalizedMonoBehaviour {
        //    var buff = new object[] { 0 };
        //    return (GroupId<T>)(object)buff;
        //}
    }
}
