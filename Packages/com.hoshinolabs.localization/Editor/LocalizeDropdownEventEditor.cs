using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.Localization {
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

            EditorGUILayout.PropertyField(optionsProperty);
            EditorGUILayout.PropertyField(updateOptionsProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
