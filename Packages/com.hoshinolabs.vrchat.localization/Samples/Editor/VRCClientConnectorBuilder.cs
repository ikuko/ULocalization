using HoshinoLabs.Localization.Samples.Udon;
using HoshinoLabs.Sardinject;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoshinoLabs.Localization.Samples {
    internal sealed class VRCClientConnectorBuilder : IProcessSceneWithReport {
        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report) {
            var context = ProjectContext.New();
            context.Enqueue(builder => {
                builder.AddInHierarchy<VRCClientConnector>();
            });
            context.Build();
        }
    }
}
