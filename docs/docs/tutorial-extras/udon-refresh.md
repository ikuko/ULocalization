---
sidebar_position: 3
---

# Udon Refresh

Udon から任意のタイミングでローカライズの更新を行うことができます。  

### Udon から更新を実行する

以下のような Udon が存在するとします。  
この Udon は `ReloadText` メソッドが呼び出されたときに特定のローカライズテキストの更新を要求します。  

```csharp
public class LocalizeReload : UdonSharpBehaviour {
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
        ProjectContext.Enqueue(builder => {
            var go = GameObject.Find("Canvas/Panel/Text (TMP)");
            var localize = go.GetComponent<LocalizeStringEvent>();
            var groupId = localize.GetRuntimeGroupId();

            builder.AddInHierarchy<LocalizeReload>()
                .WithParameter("groupId", groupId);
        });
    }
}
```

以上で `LocalizeReload.ReloadText` が呼び出されるとローカライズテキストの更新が要求されます。
