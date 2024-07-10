using UdonSharp;
using UnityEngine;
using UnityEngine.Localization;
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

        public virtual void Refresh(GroupId id) { }
        public virtual void Refresh(GroupId<LocalizeStringEvent> id) { }
        public virtual void Refresh(GroupId<LocalizeDropdownEvent> id) { }

        public virtual object GetVariable(VariableId id) => null;
        public virtual object GetVariable(VariableId<LocalizeStringEvent> id) => null;
        public virtual object GetVariable(VariableId<LocalizeDropdownEvent> id) => null;
        public virtual void SetVariable(VariableId id, object value) { }
        public virtual void SetVariable(VariableId<LocalizeStringEvent> id, object value) { }
        public virtual void SetVariable(VariableId<LocalizeDropdownEvent> id, object value) { }

        public virtual object GetLocalized(GroupId id, string locale) => null;
        public virtual string GetLocalized(GroupId<LocalizeStringEvent> id, string locale) => null;
        public virtual object GetLocalized(string locale, AssetId id) => null;
        public virtual string GetLocalized(string locale, AssetId<LocalizedString> id) => null;

        public virtual void AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString> text) { }
        public virtual void AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedAsset<Sprite>> image) { }
        public virtual void AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString> text, AssetId<LocalizedAsset<Sprite>> image) { }
        public virtual void AddOptions(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString>[] options) { }
        public virtual void AddOptions(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedAsset<Sprite>>[] options) { }
        public virtual void AddOptions(GroupId<LocalizeDropdownEvent> id, int length, AssetId<LocalizedString>[] texts, AssetId<LocalizedAsset<Sprite>>[] images) { }
        public virtual void ClearOptions(GroupId<LocalizeDropdownEvent> id) { }
    }
}
