using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomEditor(typeof(LocalizeDropdownEvent))]
    [CanEditMultipleObjects]
    internal sealed class LocalizeDropdownEventEditor : Editor {
        SerializedProperty optionsProperty;
        SerializedProperty updateOptionsProperty;

        void OnEnable() {
            optionsProperty = serializedObject.FindProperty("options");
            updateOptionsProperty = serializedObject.FindProperty("updateOptions");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            EditorGUILayout.PropertyField(optionsProperty, new GUIContent($"Options"));
            EditorGUILayout.PropertyField(updateOptionsProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
