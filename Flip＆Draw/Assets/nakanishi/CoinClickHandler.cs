
using UnityEngine;

/// <summary>
/// Coinオブジェクトをクリックしたときに反転処理を呼び出すスクリプト。
/// </summary>
[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Collider2D))]
public class CoinClickHandler : MonoBehaviour
{
    private Coin _coin;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
    }

    private void OnMouseDown()
    {
        _coin.FlipFace();
    }
}
