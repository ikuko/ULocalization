using HoshinoLabs.Sardinject;
using System;
using UnityEditor;

namespace HoshinoLabs.ULocalization.Udon {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    internal class LocalizationResolver {
        static Lazy<Localization> localization;

        [InitializeOnLoadMethod]
        static void OnLoad() {
            UnityInjector.OnProjectContainerBuilt -= ProjectContainerBuilt;
            UnityInjector.OnProjectContainerBuilt += ProjectContainerBuilt;
        }

        static void ProjectContainerBuilt(Container container) {
            localization = new(() => container.Resolve<Localization>());
        }

        public static Localization Resolve() {
            return localization.Value;
        }
    }
#endif
}
