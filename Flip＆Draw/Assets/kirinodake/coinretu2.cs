using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coinオブジェクトをクリックしたときに反転処理を行うスクリプト。
/// また、UIボタンを押すことでランダムなコインまたは横一列のコインを反転させる。
/// </summary>
/// 
public class coinretu2 : MonoBehaviour
{
    // このオブジェクトにアタッチされているCoinコンポーネント
    private Coin _coin;

    // ランダムに1列（同じY座標）のコインをすべて反転させるUIボタン
    [SerializeField] private Button randomFlipButton2;
    [SerializeField] private Board _board;
    [SerializeField] private Button skillButton;        // スキルボタンの UI 要素
    [SerializeField] private int usableTurn = 3;        // スキルが使用可能になるターン数
    [SerializeField] private int maxUses = 3;           // スキルの最大使用回数
    [SerializeField] private int cooldownTurns = 2;     // スキル使用後のクールタイム（ターン数）
    [SerializeField] private bool isPlayerCard = true;  // このボタンがプレイヤー用かどうか

    public GameDirector gameDirector; // GameDirectorを参照
    private int currentUses = 0;        // 現在の使用回数
    private int cooldownRemaining = 0; // クールタイム残りターン数
    private int lastCheckedTurn = -1;  // 最後にターンをチェックしたターン番号

    // シーン上のすべてのcoinretuインスタンスを保持する静的リスト
    private static List<coinretu2> allCoins = new List<coinretu2>();

    // スクリプトが有効化されたときに呼ばれる初期化処理
    private void Awake()
    {
        // Coinコンポーネントの取得
        _coin = GetComponent<Coin>();

        // このインスタンスを全コインリストに追加
        allCoins.Add(this);

        // ランダム反転ボタンにイベントリスナーを登録
        if (randomFlipButton2 != null)
        {
            randomFlipButton2.onClick.AddListener(FlipRandom);
        }
    }

    // オブジェクトが破棄されたときに、リストから削除
    private void OnDestroy()
    {
        allCoins.Remove(this);
    }

    // シーン上のコインの中からランダムに1つを選んで反転させる
    private void FlipRandomCoin()
    {
        if (allCoins.Count == 0) return;

        // ランダムなインデックスを取得
        int randomIndex = UnityEngine.Random.Range(0, allCoins.Count);

        // 対象のコインを反転
        allCoins[randomIndex]._coin.FlipFace();
    }

    // Y座標が同じコイン（3~4をランダムで選び、すべて反転させる
    private void FlipRandom()
    {
        // 相手の駒（Whitecoinタグ）をすべて取得
        var opponentCoins = allCoins
         .Where(c => c.gameObject.CompareTag("Blackcoin"))
         .ToList();

        // 対象がいなければ終了
        if (opponentCoins.Count == 0) return;

        // 反転する数をランダムに決定（3〜5個、ただし最大は相手の駒の数）
        int flipCount = Mathf.Min(UnityEngine.Random.Range(3, 6), opponentCoins.Count);

        // ランダムに選んで反転
        var selectedCoins = opponentCoins
     .OrderBy(c => UnityEngine.Random.value)
     .Take(flipCount);

        foreach (var coin in selectedCoins)
        {
            coin._coin.FlipFace();
        }

        // マーカー削除と再配置
        GameDirector director = FindObjectOfType<GameDirector>();
        if (director != null)
        {
            _board.clearEligibleMarkers(); // これが実際のマーカー削除
            // キャッシュクリア
            _board.ClearCachedPoints();
            // 配置可能位置の更新
            _board.GetComponent<Board>().UpdateEligiblePositions(director.IsPlayerTurn() ? CoinFace.black : CoinFace.white);
        }
    }

}