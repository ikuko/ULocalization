using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UdonSharp;
using UdonSharpEditor;

namespace HoshinoLabs.ULocalization {
    internal static partial class UnityEventFilter {
        public static Dictionary<Type, HashSet<string>> AllowedUnityEventTargetTypes => allowedUnityEventTargetTypes;

        public static bool IsTargetPermitted(UnityEngine.Object target, string targetMethod) {
            if (target.GetType().IsAssignableToGenericType(typeof(IProxyTarget<>))) {
                var propertyName = targetMethod.StartsWith("set_") ? targetMethod.Replace("set_", "") : targetMethod;
                var property = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
                if (property != null) {
                    var attribute = property.GetCustomAttribute<ProxyDeclaringTargetAttribute>();
                    if (attribute != null) {
                        return true;
                    }
                }
                var method = target.GetType().GetMethod(targetMethod, BindingFlags.Instance | BindingFlags.Public);
                if (method != null) {
                    var attribute = method.GetCustomAttribute<ProxyDeclaringTargetAttribute>();
                    if (attribute != null) {
                        return true;
                    }
                }
                return false;
            }
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
