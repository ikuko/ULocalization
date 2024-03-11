---
sidebar_position: 5
---

# Udon Variables

Udon からローカル変数の値を書き換えることができます。  

### Udon からローカル変数の値を書き換える

ローカライズテキストは以下のように設定されているとします。  
![](img/udon-variables-01.png)

以下のような Udon が存在するとします。  
この Udon は `OnClick` メソッドが呼び出されると `counter` 変数をインクリメントしローカル変数に反映してからテキストを更新します。

```csharp
public class ClickCounter : UdonSharpBehaviour {
    [Inject, SerializeField, HideInInspector]
    ILocalization localization;
    [Inject, SerializeField, HideInInspector]
    int groupId;
    [Inject, SerializeField, HideInInspector]
    int variableId;

    int counter = 0;

    public void OnClick() {
        localization.SetVariable(variableId, ++counter);
        localization.RefreshString(groupId);
    }
}
```

以下のようなエディタ拡張スクリプトを用意します。  

```csharp
public class ClickCounterBuilder : IProcessSceneWithReport {
    public int callbackOrder => 0;

    public void OnProcessScene(Scene scene, BuildReport report) {
        var context = ProjectContext.New();
        context.Enqueue(builder => {
            var go = GameObject.Find("Canvas/Panel/Text (TMP)");
            var localize = go.GetComponent<LocalizeStringEvent>();
            var groupId = localize.GetRuntimeGroupId();
            var variableId = localize.GetRuntimeVariableId("counter");

            builder.AddInHierarchy<LocalizeReload>()
                .WithParameter("groupId", groupId)
                .WithParameter("variableId", variableId);
        });
        context.Build();
    }
}
```

以上で `ClickCounter.OnClick` が呼び出されるとカウントが1つずつ上がって表示されます。

<!-- ### ローカライズテキスト変数の値を書き換える

ローカライズテキストは以下のように設定されているとします。  
![](img/udon-variables-02.png)

ローカル変数で "Localized String" 型を使用した場合は以下のような処理が必要です。  
Udon は `Lottery` メソッドが呼び出されると値を書き換えることとします。

```csharp
public class ItemChanger : UdonSharpBehaviour {
    [Inject, SerializeField, HideInInspector]
    ILocalization localization;
    [Inject, SerializeField, HideInInspector]
    int groupId;
    [Inject, SerializeField, HideInInspector]
    int variableId;
    [Inject, SerializeField, HideInInspector]
    int assetIds;

    public void Lottery() {
        localization.SetVariable(variableId, assetIds[Random.Range(0, assetIds.Length)]);
        localization.RefreshString(groupId);
    }
}
```

以下のようなエディタ拡張スクリプトを用意します。  

```csharp
public class ItemChangerBuilder : IProcessSceneWithReport {
    public int callbackOrder => 0;

    public void OnProcessScene(Scene scene, BuildReport report) {
        ProjectContext.Enqueue(builder => {
            var go = GameObject.Find("Canvas/Panel/Text (TMP)");
            var localize = go.GetComponent<LocalizeStringEvent>();
            var groupId = localize.GetRuntimeGroupId();
            var variableId = localize.GetRuntimeVariableId("item");
            var assetIds = new int[] {
                localize.GetRuntimeAssetId(___),
                localize.GetRuntimeAssetId(___),
                localize.GetRuntimeAssetId(___),
            };

            builder.AddInHierarchy<LocalizeReload>()
                .WithParameter("groupId", groupId)
                .WithParameter("variableId", variableId)
                .WithParameter("assetIds", assetIds);
        });
    }
}
```

以上で `Lottery` メソッドが呼び出されるたびに "item" 変数にセットされているローカライズテキストが変更されてテキストも更新されます。 -->
