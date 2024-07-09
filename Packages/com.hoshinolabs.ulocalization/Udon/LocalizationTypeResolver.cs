using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    public static class LocalizationTypeResolver {
        public static Type ImplementationType => typeof(UdonLocalization);
    }
}
