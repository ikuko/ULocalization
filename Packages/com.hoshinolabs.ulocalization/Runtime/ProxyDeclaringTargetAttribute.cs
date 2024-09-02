using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ProxyDeclaringTargetAttribute : PropertyAttribute {
        public Type DeclaringType { get; }

        public ProxyDeclaringTargetAttribute(Type declaringType) {
            DeclaringType = declaringType;
        }
    }
}
