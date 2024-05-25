using HoshinoLabs.Localization.Samples.Udon;
using HoshinoLabs.Sardinject;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HoshinoLabs.Localization.Samples {
    internal sealed class LanguageSettingMenuBuilder : IProcessSceneWithReport {
        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report) {
            var context = ProjectContext.New();
            context.Enqueue(builder => {
                builder.AddInHierarchy<LanguageSettingMenu>();
                builder.OnBuild += container => {
                    var languageSettingMenu = container.Resolve<LanguageSettingMenu>();
                    if (languageSettingMenu) {
                        var dropdown = languageSettingMenu.GetComponentInChildren<Dropdown>();
                        dropdown.options = LocalizationExtensions.AvailableLocales
                            .Select(x => new Dropdown.OptionData($"{x.Name} ({x.Code})"))
                            .ToList();
                    }
                };
            });
            context.Build();
        }
    }
}
