using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Data;

namespace HoshinoLabs.Localization {
    internal sealed class GroupData {
        bool mode;
        int assetId;
        DataDictionary values;
        ListenerData[] listeners;

        public bool Mode => mode;
        public int AssetId => assetId;
        public DataDictionary Values => values;
        public ListenerData[] Listeners => listeners;

        internal GroupData(bool mode, int assetId, DataDictionary values, ListenerData[] listeners) {
            this.mode = mode;
            this.assetId = assetId;
            this.values = values;
            this.listeners = listeners;
        }
    }
}
