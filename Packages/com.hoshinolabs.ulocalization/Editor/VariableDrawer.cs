using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.UIElements;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(Variable<>), true)]
    internal sealed class VariableDrawer : PropertyDrawer {
        public override VisualElement CreatePropertyGUI(SerializedProperty property) {
            var valueProperty = property.FindPropertyRelative("m_Value");
            return new PropertyField(valueProperty, property.displayName);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (new EditorGUI.PropertyScope(position, label, property)) {
                var valueProperty = property.FindPropertyRelative("m_Value");
                valueProperty.serializedObject.Update();
                EditorGUI.PropertyField(position, valueProperty, label, true);
                valueProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var variableProperty = property.FindPropertyRelative("variable");
            return EditorGUI.GetPropertyHeight(variableProperty, true);
        }
    }
}
