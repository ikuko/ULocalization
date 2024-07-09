using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    [CustomPropertyDrawer(typeof(AssetId<>))]
    //[CustomPropertyDrawer(typeof(StringAssetId))]
    //[CustomPropertyDrawer(typeof(AudioClipAssetId))]
    //[CustomPropertyDrawer(typeof(TextureAssetId))]
    //[CustomPropertyDrawer(typeof(SpriteAssetId))]
    internal sealed class AssetIdDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);

            var localizedReferenceProperty = property.FindPropertyRelative("LocalizedReference");
            EditorGUI.PropertyField(position, localizedReferenceProperty, label);
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var localizedReferenceProperty = property.FindPropertyRelative("LocalizedReference");
            return EditorGUI.GetPropertyHeight(localizedReferenceProperty, true);
        }
    }
}
