using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace HoshinoLabs.Localization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ILocalization : UdonSharpBehaviour {
        public virtual string[] AvailableLocales { get; }
        public virtual string ProjectLocale { get; }

        public virtual string SelectedLocale { get; set; }

        public virtual void RefreshString(int groupId) { }
        public virtual void RefreshAsset(int groupId) { }

        public virtual string GetLocalizedString(int groupId, string locale) => null;
        public virtual object GetLocalizedAsset(int groupId, string locale) => null;
    }
}
