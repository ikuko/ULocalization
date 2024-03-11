---
sidebar_position: 2
---

# Localize Component Extensions

**Editor Only**  
`class LocalizeComponentExtensions`

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
|✔️|`bool`|`TryGetRuntimeGroupId(this LocalizeAudioClipEvent self, out int groupId)`|ローカライズリファレンスからランタイムで使用可能なグループIDを取得します。|
|✔️|`int`|`GetRuntimeGroupId(this LocalizeAudioClipEvent self)`|ローカライズコンポーネントからランタイムで使用可能なグループIDを取得します。<br />取得できなかった場合は例外がスローされます。|
|✔️|`bool`|`TryGetRuntimeGroupId(this LocalizeStringEvent self, out int groupId)`|ローカライズリファレンスからランタイムで使用可能なグループIDを取得します。|
|✔️|`int`|`GetRuntimeGroupId(this LocalizeStringEvent self)`|ローカライズコンポーネントからランタイムで使用可能なグループIDを取得します。<br />取得できなかった場合は例外がスローされます。|
|✔️|`bool`|`TryGetRuntimeGroupId(this LocalizeTextureEvent self, out int groupId)`|ローカライズリファレンスからランタイムで使用可能なグループIDを取得します。|
|✔️|`int`|`GetRuntimeGroupId(this LocalizeTextureEvent self)`|ローカライズコンポーネントからランタイムで使用可能なグループIDを取得します。<br />取得できなかった場合は例外がスローされます。|
|✔️|`bool`|`TryGetRuntimeGroupId(this LocalizeSpriteEvent self, out int groupId)`|ローカライズリファレンスからランタイムで使用可能なグループIDを取得します。|
|✔️|`int`|`GetRuntimeGroupId(this LocalizeSpriteEvent self)`|ローカライズコンポーネントからランタイムで使用可能なグループIDを取得します。<br />取得できなかった場合は例外がスローされます。|
