using UnityEngine;

public class OthelloBoard : MonoBehaviour
{
    public int[,] board = new int[8, 8]; // 盤面を2D配列で管理 (0:空白, 1:黒, 2:白)

    public void ChangePiece(int x, int y, int playerColor)
    {
        if (board[x, y] != 0) // 既に駒がある場合のみ変更可能
        {
            board[x, y] = playerColor; // 指定座標の駒をプレイヤーの色に変更
            Debug.Log($"駒を変更しました: ({x}, {y}) -> 色 {playerColor}");
        }
    }
}