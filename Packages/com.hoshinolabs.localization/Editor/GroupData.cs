using HoshinoLabs.Localization.Udon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Data;

namespace HoshinoLabs.Localization {
    internal sealed class GroupData {
        GroupMode mode;
        int assetId;
        DataDictionary values;
        ListenerData[] listeners;

        public GroupMode Mode => mode;
        public int AssetId => assetId;
        public DataDictionary Values => values;
        public ListenerData[] Listeners => listeners;

        internal GroupData(GroupMode mode, int assetId, DataDictionary values, ListenerData[] listeners) {
            this.mode = mode;
            this.assetId = assetId;
            this.values = values;
            this.listeners = listeners;
        }
    }
}
