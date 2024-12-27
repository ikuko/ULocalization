using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
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
                GameObject.DestroyImmediate(localizeEvent);
            }
            var behaviourExtensions = scene.GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren(typeof(IBehaviourExtension)));
            foreach (var behaviourExtension in behaviourExtensions) {
                GameObject.DestroyImmediate(behaviourExtension);
            }
        }
    }
}
