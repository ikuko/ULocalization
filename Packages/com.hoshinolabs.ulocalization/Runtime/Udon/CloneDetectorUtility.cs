using System;

namespace HoshinoLabs.ULocalization.Udon {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    public static class CloneDetectorUtility {
        public static Type ImplementationType => typeof(CloneDetector);
    }
#endif
}
