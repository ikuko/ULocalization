using System.Reflection;
using UdonSharp;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using VRC.SDK3.Components;
using VRC.Udon;

namespace HoshinoLabs.ULocalization {
    internal static class LocalizeComponent_VRC {
        [MenuItem("CONTEXT/UdonBehaviour/Localize")]
        static void LocalizeUdonBehaviour(MenuCommand command) {
            var target = command.context as UdonBehaviour;
            SetupForLocalizationUdonBehaviour(target);
        }

        public static MonoBehaviour SetupForLocalizationUdonBehaviour(UdonBehaviour target) {
            var comp = Undo.AddComponent<LocalizeStringEvent>(target.gameObject);
            AddPersistentListener(target, comp, "InteractionText", 0);
            return comp;
        }

        [MenuItem("CONTEXT/UdonSharpBehaviour/Localize")]
        static void LocalizeUdonSharpBehaviour(MenuCommand command) {
            var target = command.context as UdonSharpBehaviour;
            SetupForLocalizationUdonSharpBehaviour(target);
        }

        public static MonoBehaviour SetupForLocalizationUdonSharpBehaviour(UdonSharpBehaviour target) {
            var comp = Undo.AddComponent<LocalizeStringEvent>(target.gameObject);
            AddPersistentListener(target, comp, "InteractionText", 0);
            return comp;
        }

        [MenuItem("CONTEXT/VRCPickup/Localize")]
        static void LocalizeVRCPickup(MenuCommand command) {
            var target = command.context as VRCPickup;
            SetupForLocalizationVRCPickup(target);
        }

        static void BuildVRCPickupProxy(VRCPickup target, VRCPickupExtension proxy) {
            var field = typeof(VRCPickupExtension).GetField("target", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            field.SetValue(proxy, target);
        }

        public static MonoBehaviour SetupForLocalizationVRCPickup(VRCPickup target) {
            var groupIndex = Undo.GetCurrentGroup();
            var proxy = Undo.AddComponent<VRCPickupExtension>(target.gameObject);
            BuildVRCPickupProxy(target, proxy);
            Undo.IncrementCurrentGroup();
            var comp = Undo.AddComponent<LocalizeStringEvent>(target.gameObject);
            Undo.CollapseUndoOperations(groupIndex);
            AddPersistentListener(proxy, comp, "InteractionText", 0);
            AddPersistentListener(proxy, comp, "UseText", 1);
            return comp;
        }

        static void AddPersistentListener<T>(T target, LocalizeStringEvent comp, string propertyName, int index) {
            var setStringMethod = target.GetType().GetProperty(propertyName).GetSetMethod();
            var methodDelegate = System.Delegate.CreateDelegate(typeof(UnityAction<string>), target, setStringMethod) as UnityAction<string>;
            UnityEditor.Events.UnityEventTools.AddPersistentListener(comp.OnUpdateString, methodDelegate);
            comp.OnUpdateString.SetPersistentListenerState(index, UnityEventCallState.EditorAndRuntime);
        }
    }
}
