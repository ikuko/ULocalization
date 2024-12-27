using System.Collections.Generic;
using System.Reflection;
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
            var entry = LocalizationSettings.StringDatabase.GetTableEntry(tableReference, tableEntryReference, locale);
            return entry.Entry?.IsSmart ?? false;
        }

        public object GetValue(Locale locale) {
            var entry = LocalizationSettings.StringDatabase.GetTableEntry(tableReference, tableEntryReference, locale);
            if (string.IsNullOrEmpty(entry.Entry?.Value)) {
                var dict = new Dictionary<string, object>();
                dict["key"] = entry.Entry?.Key;
                dict["keyId"] = entry.Entry?.KeyId;
                dict["table"] = entry.Table;
                dict["locale"] = locale;
                var noTranslationFoundMessage = LocalizationSettings.StringDatabase.NoTranslationFoundMessage;
                var defaultNoTranslationMessageField = typeof(LocalizedStringDatabase).GetField("k_DefaultNoTranslationMessage", BindingFlags.Static | BindingFlags.NonPublic);
                var k_DefaultNoTranslationMessage = (string)defaultNoTranslationMessageField.GetValue(null);
                var format = string.IsNullOrEmpty(noTranslationFoundMessage) ? k_DefaultNoTranslationMessage : noTranslationFoundMessage;
                return format.FormatSmart(dict);
            }
            return entry.Entry.Value;
        }
    }
}
