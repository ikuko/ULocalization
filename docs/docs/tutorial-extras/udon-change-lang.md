---
sidebar_position: 3
---

# Udon Change Language

Udon から言語の変更を行うことができます。  

### Udon から言語を変更する

以下のような Udon が存在するとします。  
この Udon は `ChangeRandomLang` メソッドが呼び出されたときに使用可能な言語の中からランダムな言語へ変更します。  

```csharp
public class LanguageChange : UdonSharpBehaviour {
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
            builder.AddInHierarchy<LanguageChange>();
        });
        context.Build();
    }
}
```

以上で `LanguageChange.ChangeRandomLang` が呼び出されると言語が変更されます。
