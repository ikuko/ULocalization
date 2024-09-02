using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class BindStartupLocaleSelectorAttribute : Attribute {
        public Type BindTo { get; }

        public BindStartupLocaleSelectorAttribute(Type bindTo) {
            BindTo = bindTo;
        }
    }
}
