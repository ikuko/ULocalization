using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ProxyDeclaringTargetAttribute : PropertyAttribute {
        public Type DeclaringType { get; }

        public ProxyDeclaringTargetAttribute(System.Type declaringType) {
            DeclaringType = declaringType;
        }
    }
}
