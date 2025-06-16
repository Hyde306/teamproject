using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Collider2D))]
public class CoinClickHandler : MonoBehaviour
{
    private Coin _coin;
    public bool can_change;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
        can_change = false; // 初期状態では無効
    }

    public void EnableHandler() // UIボタンから呼び出し
    {
        can_change = true;
    }

    private void OnMouseDown()
    {
        if (can_change) // スクリプトが有効なら処理を実行
        {
            _coin.FlipFace();
            can_change = false; // 実行後に無効化
        }
    }
}