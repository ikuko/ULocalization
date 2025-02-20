---
sidebar_position: 6
---

# ワールドの連携設定

アセット導入時点で本アセットの導入は完了しています。  
そのままでは言語を切り替えることができませんのでワールドに合わせて連携用の仕組みを導入する必要があります。  
サンプルとして簡易的に動作するプレハブを用意しています。  
Udon などを用いてより複雑な動作をさせることも可能です。

### プレハブのインポート

最初に必要なプレハブを以下の手順でインポートしてください。

上部メニューバーの "Window" から "Package Manager" を選びます。
![](img/initialization-world-import-01.png)

開いたウィンドウ内の "HoshinoLabs - ULocalization" を選びます。
![](img/initialization-world-import-02.png)

右側の "Samples" を選択し下部の "Import" ボタンを押してください。
![](img/initialization-world-import-03.png)

### ユーザーの言語設定に合わせて自動で言語を切り替える

設定から変更できる言語設定に自動で連動させる方法です。

以下のプレハブをワールドに設置します。  
![](img/initialization-world-link-vrcclient-01.png)

ワールドをビルドして確認してみましょう。  
メニューから言語を切り替えてみるとワールドに設置していたテキストも連動して切り替わるようになりました。  
![](img/initialization-world-link-vrcclient-02.gif)

### 言語切り替えメニューをワールドに設置する

ワールド内のメニューから言語を選択して変更する方法です。

以下のプレハブをワールドに設置します。  
![](img/initialization-world-language-setting-menu-01.png)

ワールドをビルドして確認してみましょう。  
ドロップダウンから言語を選択するとテキストが連動して切り替わりました。  
![](img/initialization-world-language-setting-menu-02.gif)
