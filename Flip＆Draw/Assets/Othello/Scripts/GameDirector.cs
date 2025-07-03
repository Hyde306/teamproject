using UnityEngine;

// ゲーム全体の進行を管理するディレクタークラス。
// プレイヤーのターン管理(スキップも)や、ゲームの終了判定を行う。

public class GameDirector : MonoBehaviour
{
    // ボードの参照（盤面管理）
    [SerializeField] private Board _board;

    // 現在のプレイヤーを切り替えるためのフラグ（false = 黒, true = 白）
    private bool _playerSelector = false;

    // ゲーム終了フラグ
    private bool _isGameOver = false;

    private int currentTurn = 0; // 現在のターン数を管理

    // ゲームが終了しているかどうかを取得する。
    // <returns>ゲーム終了時は true</returns>

    public bool IsGameOver() => _isGameOver;
    public bool IsPlayerTurn() => !_playerSelector;
    public int GetPieceCount() => FindObjectsOfType<Piece>().Length;

    public void Update()
    {
        // ゲームが終了していなければ処理を続行
        if (!_isGameOver)
        {
            // ボードがプレイ可能状態か確認
            if (_board.CanPlay())
            {
                // 現在のプレイヤーの合法手が更新され、かつボードが満杯でない場合
                if (_board.UpdateEligiblePositions(getFace()) && !_board.IsFull())
                {
                    // マウスの左クリックでコインを置いた場合
                    if (getInput() && _board.PlaceCoinOnBoard(getFace()))
                    {
                        NextTurn(); // ターンを進める
                    }
                }
                else
                {
                    // 置ける場所がない、またはボードが満杯なのでゲーム終了
                    _isGameOver = true;
                }
            }
        }
    }

    public void NextTurn()
    {
        currentTurn++; // ターン数をカウントアップ
        _playerSelector = !_playerSelector; // プレイヤー交代
    }

    public int GetCurrentTurn()
    {
        return currentTurn; // 現在のターン数を返す
    }


    public void ClearMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("EligibleMarker");

        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        }
    }

    // 入力を取得する（左クリックが押されたかどうか）。
    // <returns>クリックされた場合は true</returns>
    public bool getInput()
    {
        return Input.GetMouseButtonDown(0); // 0 は左クリック
    }

    // 現在のプレイヤーのコイン面（黒 or 白）を取得
    // <returns>現在のプレイヤーの CoinFace</returns>
    public CoinFace getFace()
    {
        return _playerSelector ? CoinFace.white : CoinFace.black;
    }
}