using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp;
using UdonSharpEditor;

namespace HoshinoLabs.Localization {
    internal static partial class UnityEventFilter {
        public static Dictionary<Type, HashSet<string>> AllowedUnityEventTargetTypes => allowedUnityEventTargetTypes;

        public static bool IsTargetPermitted(UnityEngine.Object target, string targetMethod) {
            if (typeof(UdonSharpBehaviour).IsAssignableFrom(target.GetType())) {
                target = UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharpBehaviour)target);
            }
            if (!allowedUnityEventTargetTypes.TryGetValue(target.GetType(), out HashSet<string> allowedTargets)) {
                return false;
            }
            return allowedTargets.Contains(targetMethod);
        }
    }
}
