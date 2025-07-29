using UnityEditor;
using UnityEditor.Localization;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace HoshinoLabs.ULocalization.Udon {
    internal class AssetTableEntry : ITableEntry {
        TableReference tableReference;
        TableEntryReference tableEntryReference;

        public AssetTableEntry(TableReference tableReference, TableEntryReference tableEntryReference) {
            this.tableReference = tableReference;
            this.tableEntryReference = tableEntryReference;
        }

        public long Id {
            get {
                return tableEntryReference.KeyId;
            }
        }

        public bool GetIsSmart(Locale locale) {
            return false;
        }

        public object GetValue(Locale locale) {
            if (tableReference.ReferenceType == TableReference.Type.Empty) {
                return null;
            }
            var tableCollection = LocalizationEditorSettings.GetAssetTableCollection(tableReference);
            var table = tableCollection.GetTable(locale.Identifier) as AssetTable;
            var entry = table.GetEntryFromReference(tableEntryReference);
            if (string.IsNullOrEmpty(entry?.Guid)) {
                return null;
            }
            var assetType = tableCollection.GetEntryAssetType(tableEntryReference);
            var assetPath = AssetDatabase.GUIDToAssetPath(entry.Guid);
            return AssetDatabase.LoadAssetAtPath(assetPath, assetType);
        }
    }
}
