using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
    [CustomPropertyDrawer(typeof(VariableIdAttribute))]
    internal sealed class VariableIdAttributeDrawer : PropertyDrawer {
        readonly GUIContent labelComponent = new GUIContent("Component");
        readonly GUIContent labelVariable = new GUIContent("Variable");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (Application.isPlaying) {
                using (new EditorGUI.DisabledGroupScope(Application.isPlaying)) {
                    position.height = EditorGUIUtility.singleLineHeight;
                    EditorGUI.LabelField(position, label);
                    using (new EditorGUI.IndentLevelScope()) {
                        position.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                        EditorGUI.ObjectField(position, labelComponent, null, typeof(LocalizeStringEvent), true);
                        position.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                        EditorGUI.Popup(position, labelVariable, -1, null);
                    }
                }
            }
            else {
                TryParseVariableData(property.stringValue, out var component, out var variable);

                position.height = EditorGUIUtility.singleLineHeight;
                EditorGUI.LabelField(position, label);
                using (new EditorGUI.IndentLevelScope()) {
                    position.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                    component = EditorGUI.ObjectField(position, labelComponent, component, typeof(LocalizeStringEvent), true) as LocalizeStringEvent;
                    position.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                    using (new EditorGUI.DisabledGroupScope(component == null)) {
                        var variables = component ? component.StringReference.Keys.ToArray() : new[] { variable };
                        var selectedIndex = Array.IndexOf(variables, variable);
                        var displayedOptions = variables.Select(x => new GUIContent(x)).ToArray();
                        selectedIndex = EditorGUI.Popup(position, labelVariable, selectedIndex, displayedOptions);
                        variable = selectedIndex < 0 ? variable : variables[selectedIndex];
                    }
                }

                property.stringValue = GlobalObjectId.GetGlobalObjectIdSlow(component).ToString() + "#" + variable;
            }
        }

        bool TryParseVariableData(string value, out LocalizeStringEvent component, out string variable) {
            var idx = value.IndexOf('#');
            if (idx < 0 || !GlobalObjectId.TryParse(value.Substring(0, idx), out var id)) {
                component = null;
                variable = null;
                return false;
            }
            component = GlobalObjectId.GlobalObjectIdentifierToObjectSlow(id) as LocalizeStringEvent;
            variable = value.Substring(idx + 1);
            return true;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight
                + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
        }
    }
}
