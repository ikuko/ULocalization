using System;
using System.Collections.Generic;

namespace HoshinoLabs.ULocalization.Udon {
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

        public static IEnumerable<Type> GetBaseTypes(this Type self) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }
            while (self != typeof(object)) {
                yield return self;
                self = self.BaseType;
            }
        }
    }
}
