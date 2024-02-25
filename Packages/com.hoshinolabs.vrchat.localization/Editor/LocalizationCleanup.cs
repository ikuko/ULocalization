using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;

namespace HoshinoLabs.Localization {
    internal sealed class SardinjectCleanup : IProcessSceneWithReport {
        public int callbackOrder => 100;

        public void OnProcessScene(Scene scene, BuildReport report) {
            foreach (var x in LocalizationHelper.ReferenceGroupIds
                    .Select(x => GlobalObjectId.GlobalObjectIdentifierToObjectSlow(x.Key))
                ) {
                GameObject.DestroyImmediate(x);
            }
        }
    }
}
