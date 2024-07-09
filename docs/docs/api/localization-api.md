---
sidebar_position: 1
---

# ULocalization API

`interface ILocalization`

### Properties

|Static|Type|Name|Summary|
|---|---|---|---|
||`string[]`|`AvailableLocales`|使用可能な言語のリストを取得します。<br />ローカライズで言語設定されているものが取得できます。|
||`string`|`ProjectLocale`|プロジェクトで使用デフォルト設定されている言語が取得できます。|
||`string`|`SelectedLocale`|現在選択中の言語が取得・設定できます。|

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`void`|`RefreshString(int groupId)`|指定したローカライズテキストを強制更新します。|
||`void`|`RefreshAsset(int groupId)`|指定したローカライズアセットを強制更新します。|
||`object`|`GetVariable(int variableId)`|指定した変数を取得します。|
||`void`|`SetVariable(int variableId, object value)`|指定した変数を設定します。|
||`string`|`GetLocalizedString(int groupId, string locale)`|指定したローカライズテキストを指定言語で取得します。|
||`object`|`GetLocalizedAsset(int groupId, string locale)`|指定したローカライズアセットを指定言語で取得します。|
