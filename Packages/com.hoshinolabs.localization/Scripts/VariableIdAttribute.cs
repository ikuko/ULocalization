using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class VariableIdAttribute : PropertyAttribute {
        public VariableIdAttribute() {

        }
    }
}
