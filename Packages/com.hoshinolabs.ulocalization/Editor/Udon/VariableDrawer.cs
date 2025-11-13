using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HoshinoLabs.ULocalization.Udon {
    [CustomPropertyDrawer(typeof(Variable<>), true)]
    internal sealed class VariableDrawer : PropertyDrawer {
        public override VisualElement CreatePropertyGUI(SerializedProperty property) {
            var variableProperty = property.FindPropertyRelative("variable");
            return new PropertyField(variableProperty, variableProperty.propertyType.ToString());
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (new EditorGUI.PropertyScope(position, label, property)) {
                var variableProperty = property.FindPropertyRelative("variable");
                variableProperty.serializedObject.Update();
                EditorGUI.PropertyField(position, variableProperty, label, true);
                variableProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var variableProperty = property.FindPropertyRelative("variable");
            return EditorGUI.GetPropertyHeight(variableProperty, true);
        }
    }
}
