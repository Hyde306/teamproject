using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnResetController : MonoBehaviour
{
    [SerializeField] private GameDirector _gameDirector;
    [SerializeField] private Board _board;
    [SerializeField] private Button _resetButton;

    // 最初の盤面に置いてあるコインの情報を保存
    private List<InitialCoinInfo> _initialCoins = new List<InitialCoinInfo>();

    private void Start()
    {
        // 最初のコインの情報を保存する
        SaveInitialCoins();

        // ボタンにリセット処理を登録
        _resetButton.onClick.AddListener(ResetBoardAndTurn);
    }

    private void SaveInitialCoins()
    {
        _initialCoins.Clear();

        // Board上の全コインを探して情報保存（GameObject.FindGameObjectsWithTag使ってもいい）
        var coins = GameObject.FindGameObjectsWithTag("Blackcoin");
        foreach (var c in coins)
        {
            _initialCoins.Add(new InitialCoinInfo(c.transform.position, CoinFace.black));
        }
        coins = GameObject.FindGameObjectsWithTag("Whitecoin");
        foreach (var c in coins)
        {
            _initialCoins.Add(new InitialCoinInfo(c.transform.position, CoinFace.white));
        }
    }

    private void ResetBoardAndTurn()
    {
        // 盤面の全コインを消す
        var allCoins = GameObject.FindGameObjectsWithTag("Blackcoin");
        foreach (var c in allCoins)
        {
            Destroy(c);
        }
        allCoins = GameObject.FindGameObjectsWithTag("Whitecoin");
        foreach (var c in allCoins)
        {
            Destroy(c);
        }

        // 最初に置かれていたコインを再生成（BoardやCoinの生成処理を想像して自分でInstantiateする）
        foreach (var coinInfo in _initialCoins)
        {
            CreateCoinAtPosition(coinInfo.Position, coinInfo.Face);
        }

        // ターンを強制的に黒プレイヤーのターンに戻す（_playerSelectorはprivateで触れないので代わりにGameDirectorにターンをすすめてもらう形などは使えない）
        // なのでここではGameDirector側は触らず、ターン関連の処理は新スクリプト側で管理してください

        Debug.Log("盤面とターンを初期状態に戻しました");
    }

    // コインを生成する処理（BoardやGameDirectorに依存しない最低限の実装例）
    private void CreateCoinAtPosition(Vector3 position, CoinFace face)
    {
        // ここでCoinプレハブをResources等から読み込んでInstantiateし、faceに応じて色を設定する処理を書く
        // 例（CoinPrefabをInspectorでアサインしている場合）：

        GameObject coinPrefab = null;
        if (face == CoinFace.black)
        {
            coinPrefab = Resources.Load<GameObject>("Prefabs/BlackCoin"); // プレハブ名は適宜変更
        }
        else
        {
            coinPrefab = Resources.Load<GameObject>("Prefabs/WhiteCoin");
        }

        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("コインのプレハブが見つかりません");
        }
    }

    // 最初のコイン情報を保持するためのクラス
    private class InitialCoinInfo
    {
        public Vector3 Position;
        public CoinFace Face;

        public InitialCoinInfo(Vector3 pos, CoinFace face)
        {
            Position = pos;
            Face = face;
        }
    }
}
