using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private CoinFace currentPlayer = CoinFace.black; // 黒プレイヤーからスタート

    void Awake()
    {
        Instance = this;
    }

    public void EndTurn()
    {
        currentPlayer = currentPlayer == CoinFace.black ? CoinFace.white : CoinFace.black; // ターン切り替え
        Debug.Log(currentPlayer == CoinFace.black ? "黒プレイヤーのターン" : "白プレイヤーのターン");
    }

    public CoinFace GetCurrentPlayer()
    {
        return currentPlayer;
    }
}