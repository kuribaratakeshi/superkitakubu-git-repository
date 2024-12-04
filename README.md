## すーぱー帰宅部.featりり

https://unityroom.com/games/surperkitakubu

<br />
彼女をお家にかえすゲームです。
彼女を危険から守りましょう。
<br />
Unity1週間ゲームジャムお題「かえす」にて作成したプログラムです。
<br />


## 操作方法
<br />
マウス右クリック:押している間はゆっくりうごきます
WASDキー:移動
<br />

彼女から離れすぎると爆発します。
<br />
<br />
【コツ】
<br />
- マウス右クリックを押しながら攻撃するとサッカーボールを倒しやすいです
- 車はコーンバーに当たると爆発します。
<br />

## アプリケーションのイメージ

### スタート画面

<img src="https://github.com/user-attachments/assets/b0e930e4-1627-4e69-84f9-1c9eab2a7c92" width ="600">

### プレイ画面

<table>
<tr>
<td><img src="https://github.com/user-attachments/assets/3fb6ab48-3816-4ce2-91e6-f1739388eb4c" ></td>
<td><img src="https://github.com/user-attachments/assets/3548f715-c462-451c-a42c-c33f2367594c" ></td>
<td><img src="https://github.com/user-attachments/assets/860f4ff7-647e-4c2f-85c4-ad6f4188e4dd"></td>
</tr>
</table>

<br />

## 作成時の工夫


キャラクターやアイテムの情報をScriptableObjectクラスを用いて一括で管理にしました。
<br />

キャラクターやアイテムが接触したときの効果を選択すると表示されるインスペクターが変化し選択した効果に必要な変数のみを表示します。
<br/>
<table>
<tr>
<td><img src="https://github.com/user-attachments/assets/340fb5e1-8f41-4d31-9576-ade33089e940" ></td>
<td><img src="https://github.com/user-attachments/assets/177fc214-2c90-41cb-845f-8edb4984a5d4" ></td>
</tr>
</table>

<br/>
効果の処理をリストで管理することでコードを書かずに、効果を組み合わせて新しい効果を作成できるようになりました。
<br/>
リストの情報を上から順に処理を実行します。
<br />
<img src="https://github.com/user-attachments/assets/1ada6431-dab9-44c9-98f9-8039e9dece16" width ="450" >

上の画像のアイテムの場合だと、接触時にMAIN_PLAYER(操作しているキャラクター)とSUB_PLAYER(操作しているキャラクター)の移動速度を2秒間設定された速度に変化させ、最後にアイテムを持っているオブジェクトを削除する効果になっています。
<br />

## 使用技術

- Unity2022.3.10f1
- Git
- GitHub

<br />

## 使用アセット
- Cartoon FX Remaster Free (https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-free-109565) 
- Selected U3D Japanese Font (https://assetstore.unity.com/packages/2d/fonts/selected-u3d-japanese-font-337)


<br />
