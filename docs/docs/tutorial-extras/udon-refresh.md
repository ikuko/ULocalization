---
sidebar_position: 4
---

# Udon Refresh

Localization は言語切替のタイミングのみローカライズの更新を行います。  
変数埋め込みを行っているなどで値を更新したい場合は明示的に更新処理を呼び出す必要があります。  
自作の Udon から任意のタイミングでローカライズの更新を行うことができます。  

### Udon から更新を実行する

以下のような Udon が存在するとします。  
この Udon は `ReloadText` メソッドが呼び出されたときに特定のローカライズテキストの更新を要求します。  

```csharp
public class LocalizeTextReloader : UdonSharpBehaviour {
    [Inject, SerializeField, HideInInspector]
    ILocalization localization;
    [Inject, SerializeField, HideInInspector]
    int groupId;

    public void ReloadText() {
        localization.RefreshString(groupId);
    }
}
```

以下のようなエディタ拡張スクリプトを用意します。  

```csharp
public class LocalizeReloadBuilder : IProcessSceneWithReport {
    public int callbackOrder => 0;

    public void OnProcessScene(Scene scene, BuildReport report) {
        var context = ProjectContext.New();
        context.Enqueue(builder => {
            var go = GameObject.Find("Canvas/Panel/Text (TMP)");
            var localize = go.GetComponent<LocalizeStringEvent>();
            var groupId = localize.GetRuntimeGroupId();

            builder.AddInHierarchy<LocalizeTextReloader>()
                .WithParameter("groupId", groupId);
        });
        context.Build();
    }
}
```

以上で `LocalizeTextReloader.ReloadText` が呼び出されるとローカライズテキストの更新が要求されます。
