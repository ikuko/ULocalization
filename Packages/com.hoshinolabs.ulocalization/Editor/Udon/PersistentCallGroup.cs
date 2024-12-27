using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace HoshinoLabs.ULocalization.Udon {
    internal class PersistentCallGroup {
        readonly SerializedProperty serializedProperty;

        public PersistentCallGroup(SerializedProperty serializedProperty) {
            this.serializedProperty = serializedProperty.FindPropertyRelative("m_PersistentCalls").FindPropertyRelative("m_Calls");
        }

        public int Count => serializedProperty.arraySize;

        public PersistentCall GetListener(int index) {
            return new PersistentCall(serializedProperty.GetArrayElementAtIndex(index));
        }

        public IEnumerable<PersistentCall> GetListeners() {
            return Enumerable.Range(0, serializedProperty.arraySize)
                .Select(x => new PersistentCall(serializedProperty.GetArrayElementAtIndex(x)));
        }
    }
}
