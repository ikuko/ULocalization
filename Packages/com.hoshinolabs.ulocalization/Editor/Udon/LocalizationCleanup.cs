using System;
using System.Linq;
using System.Reflection;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

namespace HoshinoLabs.ULocalization.Udon {
    internal sealed class LocalizationCleanup : IVRCSDKBuildProcessScene {
        public override int callbackOrder => 100;

        public override void OnBuildProcessScene(Scene scene) {
            if (!LocalizationSettings.HasSettings) {
                return;
            }

            CleanupScene(scene);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoad() {
            if (!LocalizationSettings.HasSettings) {
                return;
            }

            var scenes = Enumerable.Range(0, EditorSceneManager.sceneCount)
                .Select(x => EditorSceneManager.GetSceneAt(x));
            foreach (var scene in scenes) {
                CleanupScene(scene);
            }
        }

        static void CleanupScene(Scene scene) {
            foreach (var localizeEvent in LocalizeEventCache.GetAll()) {
                localizeEvent.hideFlags = HideFlags.NotEditable | HideFlags.DontSaveInBuild;
                localizeEvent.enabled = false;

                var fields = localizeEvent.GetType().GetBaseTypes()
                    .SelectMany(x => x.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                    .Where(x => x.FieldType.IsSubclassOf(typeof(UnityEventBase)));
                foreach (var field in fields) {
                    var unityEventBase = (UnityEventBase)field.GetValue(localizeEvent);
                    if (unityEventBase == null) {
                        continue;
                    }
                    // Clear all persistent listeners
                    field.SetValue(localizeEvent, Activator.CreateInstance(unityEventBase.GetType()));
                }

            }
            var behaviourExtensions = scene.GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren(typeof(IBehaviourExtension)));
            foreach (var behaviourExtension in behaviourExtensions) {
                behaviourExtension.hideFlags = HideFlags.NotEditable | HideFlags.DontSaveInBuild;
            }
        }
    }
}
