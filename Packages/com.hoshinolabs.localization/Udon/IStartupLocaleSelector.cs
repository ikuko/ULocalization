using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace HoshinoLabs.Localization.Udon {
    /// <summary>
    /// Determines what locale should be used for the locale when the application starts.
    /// </summary>
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class IStartupLocaleSelector : UdonSharpBehaviour {
        /// <summary>
        /// Used to determine which locale should be used.
        /// </summary>
        /// <param name="availableLocales">The available locales to select from.</param>
        /// <returns>The selected locale or null. evaluate each selector until a non-null value is returned, this value will become the locale.</returns>
        public virtual string GetStartupLocale(string[] availableLocales) {
            return null;
        }
    }
}
