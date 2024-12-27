using HoshinoLabs.Sardinject;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    public class LocalizationInstaller : MonoBehaviour, IInstaller {
        static event Action<ContainerBuilder> Installers;

        public void Install(ContainerBuilder builder) {
            Installers?.Invoke(builder);
        }
    }
}
