using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    internal struct ListenerData {
        string hash;
        object target;
        object argument;

        public string Hash => hash;
        public object Target => target;
        public object Argument => argument;

        internal ListenerData(string hash, object target, object argument) {
            this.hash = hash;
            this.target = target;
            this.argument = argument;
        }
    }
}
