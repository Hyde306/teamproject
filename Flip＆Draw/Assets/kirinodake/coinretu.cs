using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Coinオブジェクトをクリックしたときに反転処理を行うスクリプト。
/// また、UIボタンを押すことでランダムなコインまたは横一列のコインを反転させる。
/// </summary>

[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Collider2D))]
public class coinretu : MonoBehaviour
{
    // このオブジェクトにアタッチされているCoinコンポーネント
    private Coin _coin;

    // ランダムな1枚のコインを反転させるボタン（インスペクターで設定）
    [SerializeField] private Button randomFlipButton;

    // ランダムな横一列のコインをすべて反転させるボタン（インスペクターで設定）
    [SerializeField] private Button randomRowFlipButton;

    // シーン内のすべてのcoinretuインスタンスを保持するリスト（staticで共有）
    private static List<coinretu> allCoins = new List<coinretu>();

    // 初期化処理
    private void Awake()
    {
        // Coinコンポーネントを取得
        _coin = GetComponent<Coin>();

        // このインスタンスをリストに追加
        allCoins.Add(this);

        // ランダム反転ボタンが設定されていれば、クリック時の処理を登録
        if (randomFlipButton != null)
        {
            randomFlipButton.onClick.AddListener(FlipRandomCoin);
        }

        // 横列反転ボタンが設定されていれば、クリック時の処理を登録
        if (randomRowFlipButton != null)
        {
            randomRowFlipButton.onClick.AddListener(FlipRandomRow);
        }
    }

    // オブジェクトが破棄されたときにリストから削除
    private void OnDestroy()
    {
        allCoins.Remove(this);
    }

    // このコインをクリックしたときに反転処理を実行
    private void OnMouseDown()
    {
        _coin.FlipFace();
    }

    // ランダムに1つのコインを選んで反転させる
    private void FlipRandomCoin()
    {
        if (allCoins.Count == 0) return;

        int randomIndex = Random.Range(0, allCoins.Count);

        allCoins[randomIndex]._coin.FlipFace();
    }

    // ランダムに選ばれたY座標の横列にあるすべてのコインを反転させる
    private void FlipRandomRow()
    {
        if (allCoins.Count == 0) return;

        // すべてのコインのY座標を取得し、重複を除いてリスト化（小数点誤差を丸めて処理）
        var yPositions = allCoins

         .Select(c => Mathf.Round(c.transform.position.y * 100f) / 100f)

         .Distinct()

         .ToList();

        // ランダムに1つのY座標を選択
        float randomY = yPositions[Random.Range(0, yPositions.Count)];

        // 選ばれたY座標と一致するコインをすべて反転
        foreach (var coin in allCoins)
        {
            float coinY = Mathf.Round(coin.transform.position.y * 100f) / 100f;

            if (Mathf.Approximately(coinY, randomY))
            {
                coin._coin.FlipFace();
            }
        }
    }
}