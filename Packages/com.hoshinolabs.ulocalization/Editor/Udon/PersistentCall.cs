using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace HoshinoLabs.ULocalization.Udon {
    internal class PersistentCall {
        readonly SerializedProperty serializedProperty;

        public PersistentCall(SerializedProperty serializedProperty) {
            this.serializedProperty = serializedProperty;
        }

        public Object Target => serializedProperty.FindPropertyRelative("m_Target").objectReferenceValue;
        public string MethodName => serializedProperty.FindPropertyRelative("m_MethodName").stringValue;
        public PersistentListenerMode Mode => (PersistentListenerMode)serializedProperty.FindPropertyRelative("m_Mode").enumValueIndex;
        public ArgumentCache Arguments => new ArgumentCache(serializedProperty.FindPropertyRelative("m_Arguments"));
        public UnityEventCallState CallState => (UnityEventCallState)serializedProperty.FindPropertyRelative("m_CallState").enumValueIndex;
    }
}
