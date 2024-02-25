using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    internal static partial class MethodSignature {
        public static string GetSignature(Type declaringType, string methodName) {
            return methodSignatures[declaringType][methodName];
        }
    }
}
