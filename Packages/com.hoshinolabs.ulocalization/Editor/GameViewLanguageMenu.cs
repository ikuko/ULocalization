using Cysharp.Threading.Tasks.Linq;
using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UIElements;
using VRC.SDK3.ClientSim;
using VRC.SDK3.ClientSim.Editor;

namespace HoshinoLabs.ULocalization {
    [InitializeOnLoad]
    public sealed class GameViewLanguageMenu : PopupField<Locale> {
        static List<GameViewLanguageMenu> gameViews = new List<GameViewLanguageMenu>();

        static GameViewLanguageMenu() {
            EditorApplication.playModeStateChanged += PlayModeStateChanged;
            if (LocalizationSettings.HasSettings && ClientSimSettings.Instance.enableClientSim && Application.isPlaying) {
                Show();
            }
        }

        public GameViewLanguageMenu(List<Locale> availableLocales) :
            base(availableLocales, 0) {
            focusable = false;
            labelElement.style.minWidth = 60;
            labelElement.style.maxWidth = 60;

            formatListItemCallback = loc => loc == null ? "None" : loc.ToString();
            formatSelectedValueCallback = loc => loc == null ? "None" : loc.ToString();
        }

        public static void Show() {
            if (!LocalizationSettings.HasSettings || !ClientSimSettings.Instance.enableClientSim) {
                return;
            }

            LocalizationEditorSettings.ShowLocaleMenuInGameView = false;

            AddToolbarsToGameViews();
        }

        public static void Hide() {
            ClearViews();
        }

        static void PlayModeStateChanged(PlayModeStateChange obj) {
            if (obj == PlayModeStateChange.EnteredPlayMode && LocalizationSettings.HasSettings && ClientSimSettings.Instance.enableClientSim) {
                Show();
            }
            else {
                Hide();
            }
        }

        static void ClearViews() {
            foreach (var gv in gameViews) {
                gv.RemoveFromHierarchy();
            }
            gameViews.Clear();
        }

        static void AddToolbarsToGameViews() {
            ClearViews();

            var availableLocales = ClientSimSettings.Instance.availableLanguages
                .Select(x => new Locale(VRCLanguageExtensions.LocaleToVRCLanguage(x), x, null))
                .ToList();

            var assembly = typeof(EditorWindow).Assembly;
            var type = assembly.GetType("UnityEditor.GameView");
            foreach (var gameView in (EditorWindow[])Resources.FindObjectsOfTypeAll(type)) {
                var menu = new GameViewLanguageMenu(availableLocales);
                menu.style.backgroundImage = EditorStyles.popup.normal.background;
                menu.RegisterValueChangedCallback((evt) => {
                    ClientSimSettings.Instance.currentLanguage = evt.newValue.Code;
#if UNITY_EDITOR
                    if (EditorWindow.HasOpenInstances<ClientSimSettingsWindow>()) {
                        var window = EditorWindow.GetWindow<ClientSimSettingsWindow>();
                        var field = typeof(ClientSimSettingsWindow).GetField("selectedLanguageIndex", BindingFlags.Instance | BindingFlags.NonPublic);
                        field.SetValue(window, Array.IndexOf(ClientSimSettings.Instance.availableLanguages, evt.newValue.Code));
                    }
#endif
                });
                menu.style.alignSelf = Align.FlexEnd;
                menu.style.top = 22;

                gameView.rootVisualElement.Add(menu);
                menu.BringToFront();
                gameViews.Add(menu);

                UniTaskAsyncEnumerable.EveryValueChanged(gameView, _ => ClientSimSettings.Instance.currentLanguage)
                    .Select(x => new Locale(VRCLanguageExtensions.LocaleToVRCLanguage(x), x, null))
                    .ForEachAsync(x => OnLanguageChanged(x));
            }
        }

        static void OnLanguageChanged(Locale locale) {
            foreach (var gv in gameViews) {
                gv.SetValueWithoutNotify(locale);
            }
        }
    }
}
