---
sidebar_position: 6
---

# ワールドの連携設定

アセット導入時点で本アセットの導入は完了しています。  
ここでは言語設定の切り替えを連携させるためのメニューなどの設置方法を説明します。  
Udon などを用いてより複雑な制御を行いたい場合は Tutorial-Extras の項目を参照してください。

### プレハブのインポート

最初に必要なプレハブを以下の手順でインポートしてください。

上部メニューバーの "Window" から "Package Manager" を選びます。
![](img/initialization-world-import-01.png)

開いたウィンドウ内の "HoshinoLabs - ULocalization" を選びます。
![](img/initialization-world-import-02.png)

右側の "Samples" を選択し下部の "Import" ボタンを押してください。
![](img/initialization-world-import-03.png)

### ユーザーの言語設定に合わせて自動で言語を切り替える

以下のプレハブをワールドに設置します。  
![](img/initialization-world-link-vrcclient-01.png)

ワールドをビルドして確認してみましょう。  
メニューから言語を切り替えてみるとワールドに設置していたテキストも連動して切り替わるようになりました。  
![](img/initialization-world-link-vrcclient-02.gif)

### 言語切り替えメニューをワールドに設置する

以下のプレハブをワールドに設置します。  
![](img/initialization-world-language-setting-menu-01.png)

ワールドをビルドして確認してみましょう。  
ドロップダウンから言語を選択するとテキストが連動して切り替わりました。  
![](img/initialization-world-language-setting-menu-02.gif)
