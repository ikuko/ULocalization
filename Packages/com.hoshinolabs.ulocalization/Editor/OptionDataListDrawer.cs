using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(LocalizeDropdownEvent.LocalizedOptionDataList), true)]
    internal sealed class OptionDataListDrawer : PropertyDrawer {
        ReorderableList reorderableList;

        void Init(SerializedProperty property, GUIContent label) {
            if (reorderableList != null) {
                return;
            }

            var optionsProperty = property.FindPropertyRelative("options");
            reorderableList = new ReorderableList(property.serializedObject, optionsProperty);
            reorderableList.drawHeaderCallback = (Rect rect) => {
                EditorGUI.LabelField(rect, label);
            };
            reorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
                var element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(rect, element, GUIContent.none);
            };
            reorderableList.elementHeightCallback = (int index) => {
                var element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
                return EditorGUI.GetPropertyHeight(element, GUIContent.none);
            };
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            Init(property, label);

            reorderableList.DoList(position);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            Init(property, label);

            return reorderableList.GetHeight();
        }
    }
}
