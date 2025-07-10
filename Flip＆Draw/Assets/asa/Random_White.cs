using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 白プレイヤーが使うランダム反転スクリプト。
/// ランダムで自分（Whitecoin）と相手（Blackcoin）のコマを3〜5個ずつ反転させる。
/// </summary>
public class Random_White : MonoBehaviour
{
    // アタッチされている Coin スクリプトの参照
    private Coin _coin;

    // UIのランダム反転ボタン
    [SerializeField] private Button randomFlipButton;

    // 盤面管理用のBoardスクリプト
    [SerializeField] private Board _board;

    // GameDirectorへの参照（ターン管理など）
    public GameDirector gameDirector;

    // シーン上の全コイン（このスクリプトがアタッチされたもの）を管理するリスト
    private static List<Random_White> allCoins = new List<Random_White>();

    // 初期化：コイン登録とボタンイベント設定
    private void Awake()
    {
        _coin = GetComponent<Coin>();
        allCoins.Add(this);

        if (randomFlipButton != null)
        {
            // ボタンが押されたときに FlipRandom() を呼び出す
            randomFlipButton.onClick.AddListener(FlipRandom);
        }
    }

    // コインが削除されたとき、リストからも除外
    private void OnDestroy()
    {
        allCoins.Remove(this);
    }

    /// <summary>
    /// 自分と相手のコマをランダムにそれぞれ3〜5個反転させる
    /// </summary>
    private void FlipRandom()
    {
        // 自分（Whitecoin）のコマをすべて取得
        var myCoins = allCoins
            .Where(c => c.gameObject.CompareTag("Whitecoin"))
            .ToList();

        // 相手（Blackcoin）のコマをすべて取得
        var opponentCoins = allCoins
            .Where(c => c.gameObject.CompareTag("Blackcoin"))
            .ToList();

        // 自分のコマを3〜5個ランダムで選び反転
        int myFlipCount = Mathf.Min(UnityEngine.Random.Range(3, 6), myCoins.Count);
        var selectedMyCoins = myCoins
            .OrderBy(c => UnityEngine.Random.value)
            .Take(myFlipCount);

        foreach (var coin in selectedMyCoins)
        {
            coin._coin.FlipFace(); // White → Black に反転
        }

        // 相手のコマを3〜5個ランダムで選び反転
        int opponentFlipCount = Mathf.Min(UnityEngine.Random.Range(3, 6), opponentCoins.Count);
        var selectedOpponentCoins = opponentCoins
            .OrderBy(c => UnityEngine.Random.value)
            .Take(opponentFlipCount);

        foreach (var coin in selectedOpponentCoins)
        {
            coin._coin.FlipFace(); // Black → White に反転
        }

        // マーカー削除と再配置
        GameDirector director = FindObjectOfType<GameDirector>();
        if (director != null)
        {
            _board.ClearCachedPoints();
            _board.GetComponent<Board>().UpdateEligiblePositions(
                director.IsPlayerTurn() ? CoinFace.black : CoinFace.white
            );
        }
    }
}
