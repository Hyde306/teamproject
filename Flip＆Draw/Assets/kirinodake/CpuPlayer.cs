using Lacobus.Animation;
using Lacobus.Grid;// グリッドシステムを使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuPlayer : MonoBehaviour
{
    // 現在のコインの面（白 or 黒）
    [SerializeField] private CoinFace _currentFace;

    // 盤面のサイズ（例：8x8）
    private int boardSize = 8;

    // 盤面の状態を表す（0=空き、1=プレイヤー、2=CPUなど）
    private int[,] board;

    void Start()
    {
        board = new int[boardSize, boardSize];
        // ここで初期盤面セットアップなど
    }

    // CPUのターンで駒をランダムに置くメソッド
    public void PlayRandom()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // 盤面全体をチェックして、置ける場所をリストに集める
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                if (CanPlaceAt(x, y))
                {
                    validMoves.Add(new Vector2Int(x, y));
                }
            }
        }

        // 置ける場所がなければ何もしない
        if (validMoves.Count == 0)
        {
            Debug.Log("CPUは置ける場所がありません");
            return;
        }

        // ランダムに1か所選ぶ
        int index = Random.Range(0, validMoves.Count);
        Vector2Int move = validMoves[index];

        // 駒を置く処理（ここはゲームに合わせて実装）
        PlacePiece(move.x, move.y);

        Debug.Log($"CPUは ({move.x}, {move.y}) に駒を置きました");
    }

    // ここに「そのマスに置けるか」の判定を書く
    private bool CanPlaceAt(int x, int y)
    {
        // 空きマスかどうかだけ判定（本当はオセロルールで判定）
        return board[x, y] == 0;
    }

    // 駒を置く処理の例
    private void PlacePiece(int x, int y)
    {
        // 2をCPUの駒とする
        board[x, y] = 2;
        // ひっくり返す処理などもここに書く

        // 現在の面を切り替える
        switch (_currentFace)
        {
            case CoinFace.black:
                _currentFace = CoinFace.white;
                break;
            case CoinFace.white:
                _currentFace = CoinFace.black;
                break;
        }
    }
}
