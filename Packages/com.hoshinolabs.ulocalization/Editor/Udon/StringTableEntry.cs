using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Localization;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat;
using UnityEngine.Localization.Tables;

namespace HoshinoLabs.ULocalization.Udon {
    internal class StringTableEntry : ITableEntry {
        TableReference tableReference;
        TableEntryReference tableEntryReference;

        public StringTableEntry(TableReference tableReference, TableEntryReference tableEntryReference) {
            this.tableReference = tableReference;
            this.tableEntryReference = tableEntryReference;
        }

        public long Id {
            get {
                return tableEntryReference.KeyId;
            }
        }

        public bool GetIsSmart(Locale locale) {
            var tableCollection = LocalizationEditorSettings.GetStringTableCollection(tableReference);
            var table = tableCollection.GetTable(locale.Identifier) as StringTable;
            var entry = table.GetEntryFromReference(tableEntryReference);
            if (entry == null) {
                return false;
            }
            return entry.IsSmart;
        }

        public object GetValue(Locale locale) {
            var tableCollection = LocalizationEditorSettings.GetStringTableCollection(tableReference);
            var table = tableCollection.GetTable(locale.Identifier) as StringTable;
            var entry = table.GetEntryFromReference(tableEntryReference);
            if (string.IsNullOrEmpty(entry?.Value)) {
                var dict = new Dictionary<string, object>();
                dict["key"] = entry?.Key;
                dict["keyId"] = entry?.KeyId;
                dict["table"] = table;
                dict["locale"] = locale;
                var noTranslationFoundMessage = LocalizationSettings.StringDatabase.NoTranslationFoundMessage;
                var defaultNoTranslationMessageField = typeof(LocalizedStringDatabase).GetField("k_DefaultNoTranslationMessage", BindingFlags.Static | BindingFlags.NonPublic);
                var k_DefaultNoTranslationMessage = (string)defaultNoTranslationMessageField.GetValue(null);
                var format = string.IsNullOrEmpty(noTranslationFoundMessage) ? k_DefaultNoTranslationMessage : noTranslationFoundMessage;
                return format.FormatSmart(dict);
            }
            return entry.Value;
        }
    }
}
