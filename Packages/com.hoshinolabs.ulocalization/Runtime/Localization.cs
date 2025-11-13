using HoshinoLabs.Sardinal;
using HoshinoLabs.Sardinject;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace HoshinoLabs.ULocalization {
    public sealed class Localization {
        public string[] AvailableLocales => LocalizationSettings.AvailableLocales.Locales.Select(x => x.Identifier.Code).ToArray();
        public string SelectedLocale {
            get => LocalizationSettings.SelectedLocale.Identifier.Code;
            set => SetSelectedLocale(value);
        }
        public string ProjectLocale => LocalizationSettings.ProjectLocale?.Identifier.Code;

        void SetSelectedLocale(string locale) {
            if (LocalizationSettings.SelectedLocale.Identifier.Code == locale) {
                return;
            }
            var idx = LocalizationSettings.AvailableLocales.Locales.FindIndex(x => x.Identifier.Code == locale);
            if (idx < 0) {
                Logger.LogWarning($"Locale {locale} is not supported, ignoring the change.");
                return;
            }
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[idx];
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoad() {
            var signal = new Signal<Localization>();
            signal.Publish(LocalizationSettings.ProjectLocale.Identifier.Code);
            LocalizationSettings.SelectedLocaleChanged += locale => {
                signal.Publish(locale.Identifier.Code);
            };
        }
    }
}
