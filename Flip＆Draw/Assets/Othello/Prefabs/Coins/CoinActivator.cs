using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    public string coinTag = "Coin"; // Unityで設定したタグ名

    public void ActivateCoinHandler()
    {
        GameObject[] coinObjects = GameObject.FindGameObjectsWithTag(coinTag);
        foreach (GameObject coinObj in coinObjects)
        {
            CoinClickHandler handler = coinObj.GetComponent<CoinClickHandler>();
            if (handler != null)
            {
                handler.EnableHandler();
            }
        }

        // マーカー再配置処理を追加
        GameDirector director = FindObjectOfType<GameDirector>();
        Board board = director.GetComponent<Board>();

        if (board != null)
        {
            board.ClearCachedPoints();
            board.clearEligibleMarkers();

            CoinFace currentFace = director.IsPlayerTurn() ? CoinFace.black : CoinFace.white;
            board.UpdateEligiblePositions(currentFace); // これでマーカーが再描画される
        }
    }

}
