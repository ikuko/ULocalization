using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(VariableId<>))]
    [CustomPropertyDrawer(typeof(VariableId))]
    internal class VariableIdDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rowPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.LabelField(rowPosition, label);
            using (new EditorGUI.IndentLevelScope()) {
                var localizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
                rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(rowPosition, localizedEventProperty, new GUIContent("Group"));
                switch (localizedEventProperty.objectReferenceValue) {
                    case LocalizeStringEvent: {
                            OnGUI_LocalizeStringEvent(rowPosition, property, localizedEventProperty);
                            break;
                        }
                    case LocalizeDropdownEvent: {
                            OnGUI_LocalizeDropdownEvent(rowPosition, property, localizedEventProperty);
                            break;
                        }
                }
            }
            EditorGUI.EndProperty();
        }

        protected void OnGUI_LocalizeStringEvent(Rect position, SerializedProperty property, SerializedProperty localizedEventProperty) {
            var localizeStringEvent = (LocalizeStringEvent)localizedEventProperty.objectReferenceValue;
            using (new EditorGUI.DisabledGroupScope(localizeStringEvent == null)) {
                var variableNameProperty = property.FindPropertyRelative("VariableName");
                var variableName = variableNameProperty.stringValue;
                var variableNames = localizeStringEvent
                    ? localizeStringEvent.StringReference.Keys.ToArray()
                    : new[] { variableName };
                var selectedIndex = Array.IndexOf(variableNames, variableName);
                var displayedOptions = variableNames.Select(x => new GUIContent(x)).ToArray();
                position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
                selectedIndex = EditorGUI.Popup(position, new GUIContent("Variable Name"), selectedIndex, displayedOptions);
                variableNameProperty.stringValue = selectedIndex < 0 ? variableName : variableNames[selectedIndex];
            }
        }

        protected void OnGUI_LocalizeDropdownEvent(Rect position, SerializedProperty property, SerializedProperty localizedEventProperty) {
            var localizeDropdownEvent = (LocalizeDropdownEvent)localizedEventProperty.objectReferenceValue;
            using (new EditorGUI.DisabledGroupScope(localizeDropdownEvent == null)) {
                var tableReferenceIdProperty = property.FindPropertyRelative("TableReferenceId");
                Guid.TryParse(tableReferenceIdProperty.stringValue, out var tableReferenceId);
                var entryReferenceIdProperty = property.FindPropertyRelative("EntryReferenceId");
                long.TryParse(entryReferenceIdProperty.stringValue, out var entryReferenceId);
                var localizedString = new LocalizedString(tableReferenceId, entryReferenceId);
                var localizedStrings = localizeDropdownEvent
                    ? localizeDropdownEvent.Options.Select(x => x.Text).ToArray()
                    : new[] { localizedString };
                var localizedStringSelectedIndex = localizedStrings.ToList().FindIndex(x => LocalizedReferenceExtensions.Equals(x, localizedString));
                var localizedStringDisplayedOptions = localizedStrings.Select((x, i) => x.ToLabel<string>($"{i}: {{0}}")).ToArray();
                position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
                localizedStringSelectedIndex = EditorGUI.Popup(position, new GUIContent("Option"), localizedStringSelectedIndex, localizedStringDisplayedOptions);
                tableReferenceIdProperty.stringValue = localizedStringSelectedIndex < 0
                    ? localizedString?.TableReference.TableCollectionNameGuid.ToString()
                    : localizedStrings[localizedStringSelectedIndex].TableReference.TableCollectionNameGuid.ToString();
                entryReferenceIdProperty.stringValue = localizedStringSelectedIndex < 0
                    ? localizedString?.TableEntryReference.KeyId.ToString()
                    : localizedStrings[localizedStringSelectedIndex].TableEntryReference.KeyId.ToString();
                using (new EditorGUI.DisabledGroupScope(localizedStringSelectedIndex < 0)) {
                    var variableNameProperty = property.FindPropertyRelative("VariableName");
                    var variableName = variableNameProperty.stringValue;
                    var variableNames = localizedStringSelectedIndex < 0
                        ? new[] { variableName }
                        : localizedStrings[localizedStringSelectedIndex].Keys.ToArray();
                    var variableNameSelectedIndex = Array.IndexOf(variableNames, variableName);
                    var variableNameDisplayedOptions = variableNames.Select(x => new GUIContent(x)).ToArray();
                    position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
                    variableNameSelectedIndex = EditorGUI.Popup(position, new GUIContent("Variable Name"), variableNameSelectedIndex, variableNameDisplayedOptions);
                    variableNameProperty.stringValue = variableNameSelectedIndex < 0
                        ? variableName
                        : variableNames[variableNameSelectedIndex];
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var LocalizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
            switch (LocalizedEventProperty.objectReferenceValue) {
                case LocalizeStringEvent localizeStringEvent: {
                        return GetPropertyHeight_LocalizeStringEvent();
                    }
                case LocalizeDropdownEvent localizeDropdownEvent: {
                        return GetPropertyHeight_LocalizeDropdownEvent();
                    }
                default: {
                        return EditorGUIUtility.singleLineHeight
                            + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                    }
            }
        }

        protected float GetPropertyHeight_LocalizeStringEvent() {
            return EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
        }

        protected float GetPropertyHeight_LocalizeDropdownEvent() {
            return EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
        }
    }
}
