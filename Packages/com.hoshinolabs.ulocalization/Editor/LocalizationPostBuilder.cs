using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UdonSharp;
using UdonSharpEditor;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace HoshinoLabs.ULocalization {
    internal sealed class LocalizationPostBuilder : IProcessSceneWithReport {
        public int callbackOrder => 100;

        public void OnProcessScene(Scene scene, BuildReport report) {
            if (!LocalizationSettings.HasSettings) {
                return;
            }

            foreach (var x in LocalizationHelper.ReferenceGroupIds.Keys) {
                GameObject.DestroyImmediate(x);
            }
            foreach (var x in GameObject.FindObjectsOfType<MonoBehaviour>().Where(x => x.GetType().GetInterfaces().Contains(typeof(IProxyTarget)))) {
                GameObject.DestroyImmediate(x);
            }
        }
    }
}
