using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(VariableId<LocalizeDropdownEvent>))]
    internal sealed class VariableIdLocalizeDropdownEventDrawer : VariableIdDrawer<LocalizeDropdownEvent> {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rowPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.LabelField(rowPosition, label);
            using (new EditorGUI.IndentLevelScope()) {
                var LocalizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
                rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(rowPosition, LocalizedEventProperty, new GUIContent("Group"));
                var localizeDropdownEvent = (LocalizeDropdownEvent)LocalizedEventProperty.objectReferenceValue;
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
                    rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                    localizedStringSelectedIndex = EditorGUI.Popup(rowPosition, new GUIContent("Option"), localizedStringSelectedIndex, localizedStringDisplayedOptions);
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
                        rowPosition.y += rowPosition.height + EditorGUIUtility.standardVerticalSpacing;
                        variableNameSelectedIndex = EditorGUI.Popup(rowPosition, new GUIContent("Variable"), variableNameSelectedIndex, variableNameDisplayedOptions);
                        variableNameProperty.stringValue = variableNameSelectedIndex < 0
                            ? variableName
                            : variableNames[variableNameSelectedIndex];
                    }
                }
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
        }
    }
}
