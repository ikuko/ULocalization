using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    internal class TableEntryData<T> {
        T value;

        public T Value => value;

        internal TableEntryData(T value) {
            this.value = value;
        }
    }
}
