---
sidebar_position: 5
---

# Startup Locale Selector API

## IStartupLocaleSelector

`abstract class IStartupLocaleSelector`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`string`|`GetStartupLocale(string[] availableLocales)`|選択するべき言語がある場合は言語を返却します。|

## SystemLocaleSelector

`class SystemLocaleSelector`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`string`|`GetStartupLocale(string[] availableLocales)`|ユーザーの言語設定を読み取り利用可能な場合は返却します。|

## SpecificLocaleSelector

`abstract class SpecificLocaleSelector`

### Properties

### Methods

|Static|Returns|Name|Summary|
|---|---|---|---|
||`string`|`GetStartupLocale(string[] availableLocales)`|指定された言語を返却します。|
