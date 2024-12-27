using HoshinoLabs.Sardinject;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization.Udon {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    public static class LocalizeEventCache {
        static List<LocalizedMonoBehaviour> localizeEvents = new();

        [InitializeOnLoadMethod]
        static void OnLoad() {
            var installersField = typeof(LocalizationInstaller).GetField("Installers", BindingFlags.Static | BindingFlags.NonPublic);
            var installers = (Action<ContainerBuilder>)installersField.GetValue(null);
            installers -= Clear;
            installers += Clear;
            installersField.SetValue(null, installers);
        }

        static void Clear(ContainerBuilder builder) {
            localizeEvents.Clear();
        }

        public static int AddOrGet(LocalizedMonoBehaviour localizeEvent) {
            if (localizeEvent == null) {
                return -1;
            }
            if (!localizeEvents.Contains(localizeEvent)) {
                localizeEvents.Add(localizeEvent);
            }
            return localizeEvents.IndexOf(localizeEvent);
        }

        public static int AddOrGet(UnityEngine.Localization.Components.LocalizeStringEvent localizeEvent) {
            LocalizedCache.AddOrGet(localizeEvent?.StringReference, localizeEvent);
            return AddOrGet((LocalizedMonoBehaviour)localizeEvent);
        }

        public static int AddOrGet<T, U, V>(LocalizedAssetEvent<T, U, V> localizeEvent)
            where T : UnityEngine.Object
            where U : UnityEngine.Localization.LocalizedAsset<T>, new()
            where V : UnityEvent<T>, new() {
            LocalizedCache.AddOrGet(localizeEvent?.AssetReference, localizeEvent);
            return AddOrGet((LocalizedMonoBehaviour)localizeEvent);
        }

        public static int AddOrGet(ULocalization.LocalizeDropdownEvent localizeEvent) {
            LocalizedCache.AddOrGet(localizeEvent?.Options, localizeEvent);
            return AddOrGet((LocalizedMonoBehaviour)localizeEvent);
        }

        public static IEnumerable<LocalizedMonoBehaviour> GetAll() {
            return localizeEvents;
        }
    }
#endif
}
