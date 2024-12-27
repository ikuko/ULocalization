using HoshinoLabs.Sardinject;
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    internal static class LocalizationInjector {
        [InitializeOnLoadMethod]
        static void OnLoad() {
            var installersField = typeof(LocalizationInstaller).GetField("Installers", BindingFlags.Static | BindingFlags.NonPublic);
            var installers = (Action<ContainerBuilder>)installersField.GetValue(null);
            installers -= OverrideLocalizationInjection;
            installers += OverrideLocalizationInjection;
            installersField.SetValue(null, installers);
        }

        static void OverrideLocalizationInjection(ContainerBuilder builder) {
            builder.OverrideLocalizationInjection()
                .UnderTransform(() => {
                    var rootGo = new GameObject($"__{typeof(LocalizationInstaller).Namespace.Replace('.', '_')}__");
                    //rootGo.hideFlags = HideFlags.HideInHierarchy;
                    return rootGo.transform;
                });
        }
    }
}
