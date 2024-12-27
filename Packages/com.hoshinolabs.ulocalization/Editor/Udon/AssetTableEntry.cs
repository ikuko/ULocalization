using UnityEditor;
using UnityEditor.Localization;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
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
            var entry = LocalizationSettings.AssetDatabase.GetTableEntry(tableReference, tableEntryReference, locale);
            if (string.IsNullOrEmpty(entry.Entry?.Guid)) {
                return null;
            }
            var table = LocalizationEditorSettings.GetAssetTableCollection(tableReference);
            var assetType = table.GetEntryAssetType(tableEntryReference);
            var assetPath = AssetDatabase.GUIDToAssetPath(entry.Entry.Guid);
            return AssetDatabase.LoadAssetAtPath(assetPath, assetType);
        }
    }
}
