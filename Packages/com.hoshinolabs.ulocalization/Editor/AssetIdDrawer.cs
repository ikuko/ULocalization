using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(AssetId<>))]
    [CustomPropertyDrawer(typeof(AssetId))]
    internal sealed class AssetIdDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);

            var localizedReferenceProperty = property.FindPropertyRelative("LocalizedReference");
            if (localizedReferenceProperty == null) {
                EditorGUI.LabelField(position, label);
            }
            else {
                EditorGUI.PropertyField(position, localizedReferenceProperty, label);
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var localizedReferenceProperty = property.FindPropertyRelative("LocalizedReference");
            if (localizedReferenceProperty == null) {
                return EditorGUIUtility.singleLineHeight;
            }
            return EditorGUI.GetPropertyHeight(localizedReferenceProperty, true);
        }
    }
}
