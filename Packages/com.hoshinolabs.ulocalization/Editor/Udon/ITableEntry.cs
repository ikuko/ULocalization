using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization.Udon {
    interface ITableEntry {
        long Id { get; }

        object GetValue(Locale locale);
        bool GetIsSmart(Locale locale);
    }
}
