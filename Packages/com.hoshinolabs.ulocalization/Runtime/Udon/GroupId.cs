using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public class GroupId<T> where T : LocalizedMonoBehaviour {
        [SerializeField]
        public T LocalizedEvent;

        public GroupId() {

        }
    }

    [Serializable]
    public class GroupId : GroupId<LocalizedMonoBehaviour> { }
}
