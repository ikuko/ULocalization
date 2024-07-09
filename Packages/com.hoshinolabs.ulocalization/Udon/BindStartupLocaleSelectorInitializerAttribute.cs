using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class BindStartupLocaleSelectorInitializer : Attribute {
        public BindStartupLocaleSelectorInitializer() {

        }
    }
}
