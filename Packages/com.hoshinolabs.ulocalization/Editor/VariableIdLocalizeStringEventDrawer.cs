using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(VariableId<LocalizeStringEvent>))]
    internal sealed class VariableIdLocalizeStringEventDrawer : VariableIdDrawer<LocalizeStringEvent> {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rowPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.LabelField(rowPosition, label);
            using (new EditorGUI.IndentLevelScope()) {
                var LocalizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
                rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(rowPosition, LocalizedEventProperty, new GUIContent("Group"));
                var localizedStringEvent = (LocalizeStringEvent)LocalizedEventProperty.objectReferenceValue;
                using (new EditorGUI.DisabledGroupScope(localizedStringEvent == null)) {
                    var variableNameProperty = property.FindPropertyRelative("VariableName");
                    var variableName = variableNameProperty.stringValue;
                    var variableNames = localizedStringEvent
                        ? localizedStringEvent.StringReference.Keys.ToArray()
                        : new[] { variableName };
                    var selectedIndex = Array.IndexOf(variableNames, variableName);
                    var displayedOptions = variableNames.Select(x => new GUIContent(x)).ToArray();
                    rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                    selectedIndex = EditorGUI.Popup(rowPosition, new GUIContent("Variable"), selectedIndex, displayedOptions);
                    variableNameProperty.stringValue = selectedIndex < 0 ? variableName : variableNames[selectedIndex];
                }
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
        }
    }
}
