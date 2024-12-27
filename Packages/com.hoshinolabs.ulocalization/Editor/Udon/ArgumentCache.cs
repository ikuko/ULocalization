using UnityEditor;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    internal class ArgumentCache {
        readonly SerializedProperty serializedProperty;

        public ArgumentCache(SerializedProperty serializedProperty) {
            this.serializedProperty = serializedProperty;
        }

        public Object UnityObjectArgument => serializedProperty.FindPropertyRelative("m_ObjectArgument").objectReferenceValue;
        public int IntArgument => serializedProperty.FindPropertyRelative("m_IntArgument").intValue;
        public float FloatArgument => serializedProperty.FindPropertyRelative("m_FloatArgument").floatValue;
        public string StringArgument => serializedProperty.FindPropertyRelative("m_StringArgument").stringValue;
        public bool BoolArgument => serializedProperty.FindPropertyRelative("m_BoolArgument").boolValue;
    }
}
