---
sidebar_position: 2
---

# Udon でローカライズの強制更新を行う

ULocalization は言語切替のタイミングのみローカライズの更新を行います。  
変数埋め込みを行っているなどで値を更新したい場合は明示的に更新処理を呼び出す必要があります。  
自作の Udon から任意のタイミングでローカライズの更新を行うことができます。  

### Udon から更新を実行する

以下のような Udon が存在するとします。  
この Udon は `ReloadText` メソッドが呼び出されたときに特定のローカライズテキストの更新を要求します。  

```csharp
public class LocalizeTextReloader : UdonSharpBehaviour {
    [SerializeField]
    LocalizeStringEvent localizeStringEvent;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            localizeStringEvent.RefreshString();
        }
    }
}
```

インスペクタから対象とする LocalizeString コンポーネントを指定しておきます。  
以上で `2キー` を押すとローカライズテキストの強制更新が要求されます。
