---
sidebar_position: 3
---

# Udon Change Language

`VRCClientConnector` プレハブをワールドに設置することで自動的に言語設定に追従させることができます。  
言語切替の挙動をカスタマイズしたい場合はこのプレハブを使わずに自作の Udon から言語の変更を行うことができます。  

### Udon から言語を変更する

以下のような Udon が存在するとします。  
この Udon は `ChangeRandomLang` メソッドが呼び出されたときに使用可能な言語の中からランダムな言語へ変更します。  

```csharp
public class LanguageChanger : UdonSharpBehaviour {
    [Inject, SerializeField, HideInInspector]
    ILocalization localization;

    public void ChangeRandomLang() {
        var availableLocales = localization.AvailableLocales;
        var lang = availableLocales[Random.Range(0, availableLocales.Length)];
        localization.SelectedLocale = lang;
    }
}
```

以下のようなエディタ拡張スクリプトを用意します。  
このエディタ拡張は `LanguageChange` クラスの `localization` フィールドを解決するために必要です。  

```csharp
public class LanguageChangeBuilder : IProcessSceneWithReport {
    public int callbackOrder => 0;

    public void OnProcessScene(Scene scene, BuildReport report) {
        var context = ProjectContext.New();
        context.Enqueue(builder => {
            builder.AddInHierarchy<LanguageChanger>();
        });
        context.Build();
    }
}
```

以上で `LanguageChanger.ChangeRandomLang` が呼び出されると言語が変更されます。

### Udon から言語の変更を検知する

以下のような Udon を用意します。

```csharp
public class LocalizationSubscriber : UdonSharpBehaviour {
    [SignalSubscriber(typeof(LocalizationSignal))]
    public void OnSelectedLocaleChanged(string locale) {
        Debug.Log($"Locale changed to `{locale}`.");
    }
}
```

以上で言語が変更された際に `OnSelectedLocaleChanged` メソッドが呼び出されるようになります。
