using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace HoshinoLabs.Localization {
    [CustomPropertyDrawer(typeof(LocalizeDropdownEvent.OptionDataList), true)]
    class OptionDataListDrawer : PropertyDrawer {
        ReorderableList reorderableList;

        void Init(SerializedProperty property) {
            if (reorderableList != null) {
                return;
            }

            var optionsProperty = property.FindPropertyRelative("options");
            reorderableList = new ReorderableList(property.serializedObject, optionsProperty);
            reorderableList.drawHeaderCallback = (Rect rect) => {
                GUI.Label(rect, optionsProperty.displayName);
            };
            reorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
                var property = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
                var textProperty = property.FindPropertyRelative("text");
                var imageProperty = property.FindPropertyRelative("image");

                using (new EditorGUI.IndentLevelScope()) {
                    var offset = new RectOffset(0, 0, -1, -3);
                    rect = offset.Add(rect);

                    rect.height = EditorGUI.GetPropertyHeight(textProperty, true);
                    EditorGUI.PropertyField(rect, textProperty);
                    rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;
                    rect.height = EditorGUI.GetPropertyHeight(imageProperty, true);
                    EditorGUI.PropertyField(rect, imageProperty);
                }
            };
            reorderableList.elementHeightCallback = (int index) => {
                var property = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
                var textProperty = property.FindPropertyRelative("text");
                var imageProperty = property.FindPropertyRelative("image");

                return EditorGUI.GetPropertyHeight(textProperty, true)
                    + EditorGUIUtility.standardVerticalSpacing + EditorGUI.GetPropertyHeight(imageProperty, true);
            };
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            Init(property);

            reorderableList.DoList(position);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            Init(property);

            return reorderableList.GetHeight();
        }
    }
}
