using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    internal class TableEntryData<T> {
        T value;

        public T Value => value;

        internal TableEntryData(T value) {
            this.value = value;
        }
    }
}
