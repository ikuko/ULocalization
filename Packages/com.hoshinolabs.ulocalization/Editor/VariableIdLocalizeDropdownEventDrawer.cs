using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(VariableId<LocalizeDropdownEvent>))]
    internal sealed class VariableIdLocalizeDropdownEventDrawer : VariableIdDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rowPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.LabelField(rowPosition, label);
            using (new EditorGUI.IndentLevelScope()) {
                var localizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
                rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(rowPosition, localizedEventProperty, new GUIContent("Group"));
                OnGUI_LocalizeDropdownEvent(rowPosition, property, localizedEventProperty);
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return GetPropertyHeight_LocalizeDropdownEvent();
        }
    }
}
