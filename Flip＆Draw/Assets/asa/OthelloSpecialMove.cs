using UnityEngine;
using UnityEngine.UI;

public class OthelloSpecialMove : MonoBehaviour
{
    public Button specialButton;
    private Board board; // オセロの盤面管理クラス

    void Start()
    {
        specialButton.onClick.AddListener(ChangeOpponentPiece);
        board = FindObjectOfType<Board>(); // 盤面管理クラスを取得
    }

    void ChangeOpponentPiece()
    {
        Debug.Log("特殊ボタンが押されました！");
        
        // 相手のコマを取得（ここではランダムに選択）
        OthelloCell[] opponentCells = board.GetOpponentCells();
        if (opponentCells.Length > 0)
        {
            OthelloCell selectedCell = opponentCells[Random.Range(0, opponentCells.Length)];
            selectedCell.OwnerID = board.CurrentTurn; // 自分のコマに変更
            Debug.Log($"コマ変更: {selectedCell.Location}");
        }
    }
}