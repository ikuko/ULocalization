using System;
using System.Collections.Generic;
using System.Reflection;
using UdonSharp;
using UdonSharpEditor;

namespace HoshinoLabs.ULocalization.Udon {
    internal static partial class UnityEventFilter {
        public static bool IsTargetPermitted(UnityEngine.Object target, string methodName) {
            if (target.GetType().IsAssignableToGenericType(typeof(IBehaviourExtension))) {
                var propertyName = methodName.StartsWith("set_") ? methodName.Replace("set_", "") : methodName;
                var property = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
                if (property != null) {
                    var attribute = property.GetCustomAttribute<BehaviourExtensionDeclaringAttribute>();
                    if (attribute != null) {
                        return true;
                    }
                }
                var method = target.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
                if (method != null) {
                    var attribute = method.GetCustomAttribute<BehaviourExtensionDeclaringAttribute>();
                    if (attribute != null) {
                        return true;
                    }
                }
                return false;
            }
            if (typeof(UdonSharpBehaviour).IsAssignableFrom(target.GetType())) {
                target = UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharpBehaviour)target);
            }
            if (!allowedUnityEventTargetTypes.TryGetValue(target.GetType(), out Dictionary<string, string> allowedTargets)) {
                return false;
            }
            return allowedTargets.ContainsKey(methodName);
        }

        public static string GetSignature(Type declaringType, string methodName) {
            return allowedUnityEventTargetTypes[declaringType][methodName];
        }
    }
}
