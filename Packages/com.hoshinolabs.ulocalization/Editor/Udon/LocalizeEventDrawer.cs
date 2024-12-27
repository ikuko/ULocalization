using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [CustomPropertyDrawer(typeof(LocalizeEvent), true)]
    internal sealed class LocalizeEventDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (new EditorGUI.PropertyScope(position, label, property)) {
                var localizeEventProperty = property.FindPropertyRelative("localizeEvent");
                localizeEventProperty.serializedObject.Update();
                EditorGUI.PropertyField(position, localizeEventProperty, label, true);
                localizeEventProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var localizeEventProperty = property.FindPropertyRelative("localizeEvent");
            return EditorGUI.GetPropertyHeight(localizeEventProperty, true);
        }
    }
}
