using HoshinoLabs.Sardinject;
using HoshinoLabs.ULocalization.Samples.Udon;
using TMPro;
using UnityEngine;

public class LanguageSettingMenuInstaller : MonoBehaviour, IInstaller {
    public void Install(ContainerBuilder builder) {
        builder.RegisterComponentInHierarchy<TMP_Dropdown>()
            .UnderTransform(transform);
        builder.RegisterEntryPoint<LanguageSettingMenu>(Lifetime.Cached)
            .UnderTransform(transform);
    }
}
