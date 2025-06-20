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
        if (can_change)
        {
            _coin.FlipFace();
            can_change = false;

            // 他のコインの選択状態を解除
            CoinClickHandler[] allHandlers = FindObjectsOfType<CoinClickHandler>();
            foreach (CoinClickHandler handler in allHandlers)
            {
                if (handler != this)
                {
                    handler.can_change = false;
                }
            }

            // マーカー削除と再配置
            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
            {
                // マーカー削除
                GameObject[] markers = GameObject.FindGameObjectsWithTag("EligibleMarker");
                foreach (GameObject marker in markers)
                {
                    Destroy(marker);
                }

                // キャッシュクリア（必要なら）
                director.GetComponent<Board>().ClearCachedPoints();

                // 配置可能位置の更新
                director.GetComponent<Board>().UpdateEligiblePositions(director.IsPlayerTurn() ? CoinFace.black : CoinFace.white);
            }
        }
    }

}