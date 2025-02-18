---
sidebar_position: 4
---

# Variable API

## BoolVariable

`class BoolVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`bool`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(bool value)`|値を設定します。|

## SByteVariable

`class SByteVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`sbyte`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(sbyte value)`|値を設定します。|

## ByteVariable

`class ByteVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`byte`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(byte value)`|値を設定します。|

## ShortVariable

`class ShortVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`short`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(short value)`|値を設定します。|

## UShortVariable

`class UShortVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`ushort`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(ushort value)`|値を設定します。|

## IntVariable

`class IntVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`int`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(int value)`|値を設定します。|

## UIntVariable

`class UIntVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`uint`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(uint value)`|値を設定します。|

## LongVariable

`class LongVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`long`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(long value)`|値を設定します。|

## ULongVariable

`class ULongVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`ulong`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(ulong value)`|値を設定します。|

## StringVariable

`class StringVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`string`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(string value)`|値を設定します。|

## FloatVariable

`class FloatVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`float`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(float value)`|値を設定します。|

## DoubleVariable

`class DoubleVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`double`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(double value)`|値を設定します。|

## ObjectVariable

`class ObjectVariable`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`object`|`GetValue()`|設定されている値を取得します。|
||`void`|`SetValue(object value)`|値を設定します。|

## VariablesGroupAsset

`class VariablesGroupAsset`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`bool`|`TryGetValue(string name, out IVariable value)`|指定した名前の変数を取得します。|
||`bool`|`TryGetValue<T>(string name, out T value)`|指定した型と名前の変数を取得します。|
||`void`|`Add(string name, IVariable variable)`|変数を追加します。|
||`void`|`Add<T>(string name, T variable)`|変数を追加します。|
||`bool`|`Remove(string name)`|変数を削除します。|
||`bool`|`ContainsKey(string name)`|変数が存在するか確認します。|

## NestedVariablesGroup

`class NestedVariablesGroup`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`VariablesGroupAsset`|`GetValue()`|設定されている変数グループを取得します。|
||`void`|`SetValue(VariablesGroupAsset value)`|変数グループを設定します。|
