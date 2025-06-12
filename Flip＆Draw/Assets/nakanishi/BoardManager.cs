using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    private bool isSelecting = false;

    void Awake()
    {
        Instance = this;
    }

    public void ActivateSelectMode()
    {
        isSelecting = true;
        Debug.Log(GameManager.Instance.GetCurrentPlayer() == CoinFace.black ? "黒のターン - コマ選択開始" : "白のターン - コマ選択開始");
    }

    public void aaa()
    {
        if (isSelecting && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("クリック座標: " + mousePos);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null)
            {
                Debug.Log("ヒットしたオブジェクト: " + hit.gameObject.name);

                if (hit.CompareTag("OpponentPiece") || hit.CompareTag("PlayerPiece"))
                {
                    Coin coin = hit.GetComponent<Coin>();
                    if (coin != null)
                    {
                        Debug.Log("コマの反転を実行");
                        coin.FlipFace(); // コマを反転
                        Debug.Log(GameManager.Instance.GetCurrentPlayer() == CoinFace.black ? "黒がコマを変更！" : "白がコマを変更！");
                    }

                    isSelecting = false;
                    Debug.Log("ターン終了処理を実行");
                    GameManager.Instance.EndTurn(); // ターンを終了し、交代
                }
            }
        }
    }
}