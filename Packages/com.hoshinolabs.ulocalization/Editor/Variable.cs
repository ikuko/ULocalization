using HoshinoLabs.ULocalization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    internal sealed class Variable {
        VariableType type;
        object value;

        public VariableType Type => type;
        public object Value => value;

        internal Variable(VariableType type, object value) {
            this.type = type;
            this.value = value;
        }
    }
}
