using UdonSharp;
using UnityEngine;
using UnityEngine.Localization.Components;
using VRC.SDKBase;
using VRC.Udon;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ILocalization : UdonSharpBehaviour {
        public virtual string[] AvailableLocales { get; }
        public virtual string ProjectLocale { get; }

        public virtual string SelectedLocale { get; set; }

        // TODO: 型で判別できるのでRefresh()にする
        public virtual void RefreshString(GroupId id) { }
        public virtual void RefreshString(GroupId<LocalizeStringEvent> id) { }
        public virtual void RefreshString(GroupId<LocalizeDropdownEvent> id) { }
        public virtual void RefreshAsset(GroupId id) { }

        public virtual object GetVariable(VariableId<LocalizeStringEvent> variableId) => null;
        public virtual object GetVariable(VariableId<LocalizeDropdownEvent> variableId) => null;
        public virtual void SetVariable(VariableId<LocalizeStringEvent> variableId, object value) { }
        public virtual void SetVariable(VariableId<LocalizeDropdownEvent> variableId, object value) { }

        // TODO: GetLocalizedText()orGetLocalizedAsset()にする
        public virtual string GetLocalizedString(object groupId, string locale) => null;
        public virtual object GetLocalizedAsset(object groupId, string locale) => null;
        public virtual string GetLocalizedString(string locale, object assetId) => null;
        public virtual object GetLocalizedAsset(string locale, object assetId) => null;
    }
}
