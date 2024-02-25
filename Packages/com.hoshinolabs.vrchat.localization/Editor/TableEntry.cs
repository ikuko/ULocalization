using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization {
    internal sealed class TableEntry {
        string name;
        string tableId;
        string entryId;

        public string Name => name;
        public string TableId => tableId;
        public string EntryId => entryId;

        internal TableEntry(string name, string tableId, string entryId) {
            this.name = name;
            this.tableId = tableId;
            this.entryId = entryId;
        }
    }
}
