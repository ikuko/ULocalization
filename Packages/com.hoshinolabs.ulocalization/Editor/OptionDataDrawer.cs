using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(LocalizeDropdownEvent.LocalizedOptionData), true)]
    internal sealed class OptionDataDrawer : PropertyDrawer {
        bool expanded;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (new EditorGUI.PropertyScope(position, label, property)) {
                if (label == GUIContent.none) {
                    var offset = new RectOffset(-15, 0, -3, -3);
                    OnExpandedGUI(offset.Add(position), property, label);
                }
                else {
                    var foldoutPosition = new Rect(position) {
                        height = EditorGUIUtility.singleLineHeight
                    };
                    expanded = EditorGUI.Foldout(foldoutPosition, expanded, label, true);
                    if (expanded) {
                        var expandedPosition = new Rect(position) {
                            y = foldoutPosition.y + foldoutPosition.height + EditorGUIUtility.standardVerticalSpacing,
                            height = GetPropertyExpandedHeight(property, label)
                        };
                        var offset = new RectOffset(-15, 0, 0, 0);
                        OnExpandedGUI(offset.Add(expandedPosition), property, label);
                    }
                }
            }
        }

        void OnExpandedGUI(Rect position, SerializedProperty property, GUIContent label) {
            var textProperty = property.FindPropertyRelative("text");
            var textPosition = new Rect(position) {
                height = EditorGUI.GetPropertyHeight(textProperty)
            };
            EditorGUI.PropertyField(textPosition, textProperty);
            var imageProperty = property.FindPropertyRelative("image");
            var imagePosition = new Rect(textPosition) {
                y = textPosition.y + textPosition.height + EditorGUIUtility.standardVerticalSpacing,
                height = EditorGUI.GetPropertyHeight(imageProperty)
            };
            EditorGUI.PropertyField(imagePosition, imageProperty);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var height = label == GUIContent.none ? 0f : EditorGUIUtility.singleLineHeight;
            if (label == GUIContent.none || expanded) {
                height += EditorGUIUtility.standardVerticalSpacing + GetPropertyExpandedHeight(property, label);
            }
            return height;
        }

        float GetPropertyExpandedHeight(SerializedProperty property, GUIContent label) {
            var textProperty = property.FindPropertyRelative("text");
            var imageProperty = property.FindPropertyRelative("image");
            return EditorGUI.GetPropertyHeight(textProperty, label)
                + EditorGUIUtility.standardVerticalSpacing + EditorGUI.GetPropertyHeight(imageProperty, label);
        }
    }
}
