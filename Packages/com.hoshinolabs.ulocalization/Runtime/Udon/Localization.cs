using HoshinoLabs.Sardinject.Udon;
using UdonSharp;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [ImplementationType(typeof(LocalizationShim))]
    public abstract class Localization : UdonSharpBehaviour {
        public virtual string[] AvailableLocales => null;
        public virtual string SelectedLocale {
            get => null;
            set { }
        }
        public virtual string ProjectLocale => null;
    }
}
