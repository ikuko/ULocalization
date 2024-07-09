using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UdonSharp.Serialization;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;

namespace HoshinoLabs.ULocalization {
    internal sealed class GroupIdArraySerializerBuilder : IProcessSceneWithReport {
        public int callbackOrder => -5001;

        public void OnProcessScene(Scene scene, BuildReport report) {
            var typeCheckSerializersField = typeof(Serializer).GetField("_typeCheckSerializers", BindingFlags.Static | BindingFlags.NonPublic);
            var typeCheckSerializers = (List<Serializer>)typeCheckSerializersField.GetValue(null);
            typeCheckSerializers.RemoveAll(x => x.GetType() == typeof(GroupIdArraySerializer<LocalizedMonoBehaviour>));
            typeCheckSerializers.RemoveAll(x => x.GetType() == typeof(GroupIdArraySerializer));
            typeCheckSerializers.Insert(0, new GroupIdArraySerializer<LocalizedMonoBehaviour>(null));
            typeCheckSerializers.Insert(0, new GroupIdArraySerializer(null));
        }
    }
}
