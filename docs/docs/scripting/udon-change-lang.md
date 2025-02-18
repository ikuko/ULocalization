---
sidebar_position: 1
---

# Udon で言語設定を制御する

`VRCClientConnector` プレハブをワールドに設置することで自動的に言語設定に追従させることができます。  
言語切替の挙動をカスタマイズしたい場合はこのプレハブを使わずに自作の Udon から言語の変更を行うことができます。  

### Udon から言語を変更する

以下のような Udon が存在するとします。  
この Udon は `ChangeRandomLang` メソッドが呼び出されたときに使用可能な言語の中からランダムな言語へ変更します。  

```csharp
public class LanguageChanger : UdonSharpBehaviour {
    [Inject, SerializeField, HideInInspector]
    Localization localization;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            var availableLocales = localization.AvailableLocales;
            var locale = availableLocales[Random.Range(0, availableLocales.Length)];
            localization.SelectedLocale = locale;
        }
    }
}
```

以下のようなスクリプトを用意します。  
`LanguageChanger` と同じ場所にスクリプトを追加します。  
合わせて `SceneScope` コンポーネントも追加しておきます。  

```csharp
public class LanguageChangerInstaller : MonoBehaviour, IInstaller {
    public void Install(ContainerBuilder builder) {
        builder.RegisterComponentInHierarchy<LanguageChanger>()
            .UnderTransform(transform);
    }
}
```

以上で `1キー` を押すと変更可能な言語の中からランダムに言語が変更されます。

### Udon から言語の変更を検知する

以下のような Udon を用意します。

```csharp
public class LocalizationSubscriber : UdonSharpBehaviour {
    [Subscriber(typeof(Localization))]
    public void OnLocalizationLocaleChanged(string locale) {
        Debug.Log($"Locale changed to `{locale}`.");
    }
}
```

以上で言語が変更された際に `OnSelectedLocaleChanged` メソッドが呼び出されるようになります。
