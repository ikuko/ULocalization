---
sidebar_position: 3
---

# Localize Reference Extensions

**Editor Only**  
`class LocalizedReferenceExtensions`

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
|✔️|`bool`|`TryGetRuntimeAssetId(this LocalizeAudioClipEvent self, out int groupId)`|ローカライズリファレンスからランタイムで使用可能なアセットIDを取得します。|
|✔️|`int`|`GetRuntimeAssetId(this LocalizeAudioClipEvent self)`|ローカライズコンポーネントからランタイムで使用可能なアセットIDを取得します。<br />取得できなかった場合は例外がスローされます。|
