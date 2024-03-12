using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
    internal static class LocalizationHelper {
        static Locale[] availableLocales;
        static Dictionary<LocalizedMonoBehaviour, int> referenceGroupIds;
        static Dictionary<(LocalizedMonoBehaviour group, int index), int> referenceVariableIds;
        static Dictionary<(string tableId, string entryId), int> referenceStringIds;
        static Dictionary<(string tableId, string entryId), int> referenceAssetIds;
        static StringTableEntryData[][] stringDatabase;
        static AssetTableEntryData[][] assetDatabase;

        public static Locale[] AvailableLocales {
            get => availableLocales;
            internal set => availableLocales = value;
        }
        internal static Dictionary<LocalizedMonoBehaviour, int> ReferenceGroupIds {
            get => referenceGroupIds;
            set => referenceGroupIds = value;
        }
        internal static Dictionary<(LocalizedMonoBehaviour group, int index), int> ReferenceVariableIds {
            get => referenceVariableIds;
            set => referenceVariableIds = value;
        }
        internal static Dictionary<(string tableId, string entryId), int> ReferenceStringIds {
            get=>referenceStringIds;
            set => referenceStringIds = value;
        }
        internal static Dictionary<(string tableId, string entryId), int> ReferenceAssetIds {
            get => referenceAssetIds;
            set => referenceAssetIds = value;
        }
        internal static StringTableEntryData[][] StringDatabase {
            get => stringDatabase;
            set => stringDatabase = value;
        }
        internal static AssetTableEntryData[][] AssetDatabase {
            get => assetDatabase;
            set => assetDatabase = value;
        }
    }
}
