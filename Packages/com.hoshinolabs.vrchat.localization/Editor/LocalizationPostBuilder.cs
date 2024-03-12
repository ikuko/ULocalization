using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoshinoLabs.Localization {
    internal sealed class LocalizationPostBuilder : IProcessSceneWithReport {
        public int callbackOrder => 100;

        public void OnProcessScene(Scene scene, BuildReport report) {
            foreach (var x in LocalizationHelper.ReferenceGroupIds.Keys) {
                GameObject.DestroyImmediate(x);
            }
        }
    }
}
