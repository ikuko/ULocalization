using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
    [CustomPropertyDrawer(typeof(GroupIdAttribute))]
    internal sealed class GroupIdAttributeDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (Application.isPlaying) {
                using (new EditorGUI.DisabledGroupScope(Application.isPlaying)) {
                    position.height = EditorGUIUtility.singleLineHeight;
                    EditorGUI.ObjectField(position, label, null, typeof(LocalizedMonoBehaviour), true);
                }
            }
            else {
                TryParseGroupData(property.stringValue, out var component);

                position.height = EditorGUIUtility.singleLineHeight;
                component = EditorGUI.ObjectField(position, label, component, typeof(LocalizedMonoBehaviour), true) as LocalizedMonoBehaviour;

                property.stringValue = GlobalObjectId.GetGlobalObjectIdSlow(component).ToString();
            }
        }

        bool TryParseGroupData(string value, out LocalizedMonoBehaviour component) {
            if (!GlobalObjectId.TryParse(value, out var id)) {
                component = null;
                return false;
            }
            component = GlobalObjectId.GlobalObjectIdentifierToObjectSlow(id) as LocalizedMonoBehaviour;
            return true;
        }
    }
}
