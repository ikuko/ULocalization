---
sidebar_position: 4
---

# Localize Variable Extensions

**Editor Only**  
`class LocalizedVariableExtensions`

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
|✔️|`bool`|`TryGetRuntimeVariableId(this LocalizeStringEvent self, int index, out int groupId)`|ローカライズリファレンスからランタイムで使用可能な変数IDを取得します。|
|✔️|`int`|`GetRuntimeVariableId(this LocalizeStringEvent self, int index)`|ローカライズコンポーネントからランタイムで使用可能な変数IDを取得します。<br />取得できなかった場合は例外がスローされます。|
|✔️|`bool`|`TryGetRuntimeVariableId(this LocalizeStringEvent self, string name, out int groupId)`|ローカライズリファレンスからランタイムで使用可能な変数IDを取得します。|
|✔️|`int`|`GetRuntimeVariableId(this LocalizeStringEvent self, string name)`|ローカライズコンポーネントからランタイムで使用可能な変数IDを取得します。<br />取得できなかった場合は例外がスローされます。|
