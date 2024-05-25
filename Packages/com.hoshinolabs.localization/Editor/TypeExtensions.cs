using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    internal static class TypeExtensions {
        public static bool IsAssignableToGenericType(this Type self, Type type) {
            foreach (var x in self.GetInterfaces()) {
                if (x.IsGenericType && x.GetGenericTypeDefinition() == type) {
                    return true;
                }
            }
            if (self.IsGenericType && self.GetGenericTypeDefinition() == type) {
                return true;
            }
            var baseType = self.BaseType;
            if (baseType == null) {
                return false;
            }
            return IsAssignableToGenericType(baseType, type);
        }
    }
}
