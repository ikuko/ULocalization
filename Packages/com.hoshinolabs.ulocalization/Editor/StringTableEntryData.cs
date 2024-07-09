using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    internal sealed class StringTableEntryData : TableEntryData<string> {
        bool smart;

        public bool IsSmart => smart;

        internal StringTableEntryData(string value, bool smart) : base(value) {
            this.smart = smart;
        }
    }
}
