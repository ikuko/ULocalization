using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        public static FieldInfo[] GetLocalizationFields(this Type self) {
            return self.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => x.FieldType.Namespace.StartsWith(typeof(Localization).Namespace))
                .Concat(self.BaseType?.GetLocalizationFields() ?? Array.Empty<FieldInfo>())
                .ToArray();
        }
    }
}
