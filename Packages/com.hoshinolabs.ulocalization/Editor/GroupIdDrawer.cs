using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(GroupId<>))]
    [CustomPropertyDrawer(typeof(GroupId))]
    internal sealed class GroupIdDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);

            var localizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
            EditorGUI.PropertyField(position, localizedEventProperty, label);
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var localizedEventProperty = property.FindPropertyRelative("LocalizedEvent");
            return EditorGUI.GetPropertyHeight(localizedEventProperty, true);
        }
    }
}
