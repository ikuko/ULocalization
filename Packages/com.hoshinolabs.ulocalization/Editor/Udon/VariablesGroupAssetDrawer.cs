using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [CustomPropertyDrawer(typeof(VariablesGroupAsset), true)]
    internal sealed class VariablesGroupAssetDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (new EditorGUI.PropertyScope(position, label, property)) {
                var variablesGroupProperty = property.FindPropertyRelative("variablesGroup");
                variablesGroupProperty.serializedObject.Update();
                using (new EditorGUI.DisabledScope(EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isPlaying)) {
                    EditorGUI.ObjectField(position, variablesGroupProperty, typeof(UnityEngine.Localization.SmartFormat.PersistentVariables.VariablesGroupAsset), label);
                }
                variablesGroupProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var variablesGroupProperty = property.FindPropertyRelative("variablesGroup");
            return EditorGUI.GetPropertyHeight(variablesGroupProperty, true);
        }
    }
}
