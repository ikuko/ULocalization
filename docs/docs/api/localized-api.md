---
sidebar_position: 3
---

# Localized API

## LocalizedString

`class LocalizedString`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`void`|`RefreshString()`|ローカライズの強制更新を要求します。|
||`string`|`GetLocalizedString()`|ローカライズ文字列を取得します。|
||`bool`|`TryGetValue(string name, out IVariable value)`|指定した名前の変数を取得します。|
||`bool`|`TryGetValue<T>(string name, out T value)`|指定した型と名前の変数を取得します。|
||`void`|`Add(string name, IVariable variable)`|変数を追加します。|
||`void`|`Add<T>(string name, T variable)`|変数を追加します。|
||`bool`|`Remove(string name)`|変数を削除します。|
||`bool`|`bool ContainsKey(string name)`|変数が存在するか確認します。|

## LocalizedAudioClip

`class LocalizedAudioClip`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`AudioClip`|`LoadAsset()`|ローカライズアセットを取得します。|

## LocalizedOptionData

`class LocalizedOptionData`

### Properties

### Methods

## LocalizedOptionDataList

`class LocalizedOptionDataList`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`void`|`Add(LocalizedOptionData option)`|ローカライズオプションを追加します。|
||`void`|`Add(LocalizedString text)`|ローカライズオプションを追加します。|
||`void`|`Add(LocalizedSprite image)`|ローカライズオプションを追加します。|
||`void`|`Add(LocalizedString text, LocalizedSprite image)`|ローカライズオプションを追加します。|
||`void`|`RemoveAt(int index)`|指定順序のローカライズオプションを削除します。|
||`void`|`Insert(int index, LocalizedOptionData option)`|指定順序にローカライズオプションを追加します。|
||`void`|`Insert(int index, LocalizedString text)`|指定順序にローカライズオプションを追加します。|
||`void`|`Insert(int index, LocalizedSprite image)`|指定順序にローカライズオプションを追加します。|
||`void`|`Insert(int index, LocalizedString text, LocalizedSprite image)`|指定順序にローカライズオプションを追加します。|
||`void`|`Clear()`|ローカライズオプションをクリアします。|

## LocalizedSprite

`class LocalizedSprite`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`Sprite`|`LoadAsset()`|ローカライズアセットを取得します。|

## LocalizedTexture

`class LocalizedTexture`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`Texture`|`LoadAsset()`|ローカライズアセットを取得します。|
