using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(VariableId<LocalizeStringEvent>))]
    internal sealed class VariableIdLocalizeStringEventDrawer : VariableIdDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rowPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.LabelField(rowPosition, label);
            using (new EditorGUI.IndentLevelScope()) {
                var localizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
                rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(rowPosition, localizedEventProperty, new GUIContent("Group"));
                OnGUI_LocalizeStringEvent(rowPosition, property, localizedEventProperty);
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return GetPropertyHeight_LocalizeStringEvent();
        }
    }
}
