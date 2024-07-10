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
||`void`|`Refresh(GroupId id)`|指定したグループを強制更新します。|
||`void`|`Refresh(GroupId<LocalizeStringEvent> id)`|指定したグループを強制更新します。|
||`void`|`Refresh(GroupId<LocalizeDropdownEvent> id)`|指定したグループを強制更新します。|
||`object`|`GetVariable(VariableId id)`|指定した変数を取得します。|
||`object`|`GetVariable(VariableId<LocalizeStringEvent> id)`|指定した変数を取得します。|
||`object`|`GetVariable(VariableId<LocalizeDropdownEvent> id)`|指定した変数を取得します。|
||`void`|`SetVariable(VariableId id, object value)`|指定した変数を設定します。|
||`void`|`SetVariable(VariableId<LocalizeStringEvent> id, object value)`|指定した変数を設定します。|
||`void`|`SetVariable(VariableId<LocalizeDropdownEvent> id, object value)`|指定した変数を設定します。|
||`string`|`GetLocalized(GroupId id, string locale)`|指定したグループのローカライズテキストを指定言語で取得します。|
||`object`|`GetLocalized(GroupId<LocalizeStringEvent> id, string locale)`|指定したグループのローカライズアセットを指定言語で取得します。|
||`object`|`GetLocalized(string locale, AssetId id)`|指定したローカライズアセットを指定言語で取得します。|
||`object`|`GetLocalized(string locale, AssetId<LocalizedString> id)`|指定したローカライズアセットを指定言語で取得します。|
||`object`|`AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString> text)`|指定したグループのドロップダウンに指定アセットでオプションを追加します。|
||`object`|`AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedAsset<Sprite>> image)`|指定したグループのドロップダウンに指定アセットでオプションを追加します。|
||`object`|`AddOption(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString> text, AssetId<LocalizedAsset<Sprite>> image)`|指定したグループのドロップダウンに指定アセットでオプションを追加します。|
||`object`|`AddOptions(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedString>[] options)`|指定したグループのドロップダウンに指定アセットでオプションを追加します。|
||`object`|`AddOptions(GroupId<LocalizeDropdownEvent> id, AssetId<LocalizedAsset<Sprite>>[] options)`|指定したグループのドロップダウンに指定アセットでオプションを追加します。|
||`object`|`AddOptions(GroupId<LocalizeDropdownEvent> id, int length, AssetId<LocalizedString>[] texts, AssetId<LocalizedAsset<Sprite>>[] images)`|指定したグループのドロップダウンに指定アセットでオプションを追加します。|
||`object`|`ClearOptions(GroupId<LocalizeDropdownEvent> id)`|指定したグループのドロップダウンのオプションをクリアします。|
