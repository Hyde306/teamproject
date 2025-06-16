
using UnityEngine;

public class CoinFlipButton : MonoBehaviour
{
    [SerializeField] private Coin targetCoin;

    /// <summary>
    /// UIボタンから呼び出す用の関数
    /// </summary>
    public void OnFlipButtonPressed()
    {
        if (targetCoin != null)
        {
            targetCoin.FlipFace();
        }
    }
}
