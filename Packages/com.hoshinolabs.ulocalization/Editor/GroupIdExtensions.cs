using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    internal static class GroupIdExtensions {
        public static object Pack<T>(this GroupId<T> self) where T : LocalizedMonoBehaviour {
            if (self == null || self.LocalizedEvent == null
                || !self.LocalizedEvent.TryGetRuntimeGroupId(out var groupId)) {
                return null;
            }
            return new object[] {
                groupId,
            };
        }

        public static GroupId<T> UnPack<T>(object obj) where T : LocalizedMonoBehaviour {
            return null;
        }

        public static GroupId UnPack(object obj) {
            return null;
        }
    }
}
