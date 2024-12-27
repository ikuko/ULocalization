using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class BehaviourExtensionDeclaringAttribute : PropertyAttribute {
        public Type DeclaringType { get; }

        public BehaviourExtensionDeclaringAttribute(Type declaringType) {
            DeclaringType = declaringType;
        }
    }
}
