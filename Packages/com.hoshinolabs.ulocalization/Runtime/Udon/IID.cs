using HoshinoLabs.Sardinject;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace HoshinoLabs.ULocalization.Udon {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    public static class IID {
        static List<object> objects = new();

        [InitializeOnLoadMethod]
        static void OnLoad() {
            var installersField = typeof(LocalizationInstaller).GetField("Installers", BindingFlags.Static | BindingFlags.NonPublic);
            var installers = (Action<ContainerBuilder>)installersField.GetValue(null);
            installers -= Clear;
            installers += Clear;
            installersField.SetValue(null, installers);
        }

        static void Clear(ContainerBuilder builder) {
            objects.Clear();
        }

        public static int GenerateId(object key) {
            if (key == null) {
                return -1;
            }
            if (!objects.Contains(key)) {
                objects.Add(key);
            }
            return objects.IndexOf(key);
        }

        public static IEnumerable<object> GetAll() {
            return objects;
        }
    }
#endif
}
