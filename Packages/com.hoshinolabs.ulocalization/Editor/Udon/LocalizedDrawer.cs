using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [CustomPropertyDrawer(typeof(Localized), true)]
    internal sealed class LocalizedDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (new EditorGUI.PropertyScope(position, label, property)) {
                var localizedProperty = property.FindPropertyRelative("localized");
                localizedProperty.serializedObject.Update();
                EditorGUI.PropertyField(position, localizedProperty, label, true);
                localizedProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var localizedProperty = property.FindPropertyRelative("localized");
            return EditorGUI.GetPropertyHeight(localizedProperty, true);
        }
    }
}
