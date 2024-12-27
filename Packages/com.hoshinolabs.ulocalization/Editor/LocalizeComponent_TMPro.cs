using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace HoshinoLabs.ULocalization {
    internal static class LocalizeComponent_TMPro {
        [MenuItem("CONTEXT/TMP_Dropdown/Localize")]
        static void LocalizeTMPDropdown(MenuCommand command) {
            var target = command.context as TMP_Dropdown;
            SetupForLocalizationTMPDropdown(target);
        }

        static void BuildTMPDropdownProxy(TMP_Dropdown target, TMP_DropdownExtension proxy) {
            var field = typeof(TMP_DropdownExtension).GetField("target", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            field.SetValue(proxy, target);
        }

        public static MonoBehaviour SetupForLocalizationTMPDropdown(TMP_Dropdown target) {
            var groupIndex = Undo.GetCurrentGroup();
            var proxy = Undo.AddComponent<TMP_DropdownExtension>(target.gameObject);
            BuildTMPDropdownProxy(target, proxy);
            Undo.IncrementCurrentGroup();
            var comp = Undo.AddComponent<LocalizeDropdownEvent>(target.gameObject);
            Undo.CollapseUndoOperations(groupIndex);
            AddPersistentListener(proxy, comp, "options", 0);
            return comp;
        }

        static void AddPersistentListener<T>(T target, LocalizeDropdownEvent comp, string propertyName, int index) {
            var setStringMethod = target.GetType().GetProperty(propertyName).GetSetMethod();
            var methodDelegate = System.Delegate.CreateDelegate(typeof(UnityAction<TMP_Dropdown.OptionData[]>), target, setStringMethod) as UnityAction<TMP_Dropdown.OptionData[]>;
            UnityEditor.Events.UnityEventTools.AddPersistentListener(comp.OnUpdateOptions, methodDelegate);
            comp.OnUpdateOptions.SetPersistentListenerState(index, UnityEventCallState.EditorAndRuntime);
        }
    }
}
