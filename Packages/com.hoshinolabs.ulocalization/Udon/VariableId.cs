using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public class VariableId<T> where T : LocalizedMonoBehaviour {
        [SerializeField]
        public T LocalizedEvent;
        [SerializeField]
        public string TableReferenceId;
        [SerializeField]
        public string EntryReferenceId;
        [SerializeField]
        public string VariableName;

        public VariableId() {

        }
    }

    [Serializable]
    public class VariableId : VariableId<LocalizedMonoBehaviour> { }
}
