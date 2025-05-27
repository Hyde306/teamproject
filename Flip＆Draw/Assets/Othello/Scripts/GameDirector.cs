using UnityEngine;

/// <summary>
/// ゲーム全体の進行を管理するディレクタークラス。
/// プレイヤーのターン管理や、ゲームの終了判定を行う。
/// </summary>
public class GameDirector : MonoBehaviour
{
    // ----------------------
    // フィールド
    // ----------------------

    // ボードの参照（盤面管理）
    [SerializeField] private Board _board;

    // 現在のプレイヤーを切り替えるためのフラグ（false = 黒, true = 白）
    private bool _playerSelector = false;

    // ゲーム終了フラグ
    private bool _isGameOver = false;

    // ----------------------
    // パブリックメソッド
    // ----------------------

    /// <summary>
    /// ゲームが終了しているかどうかを取得する。
    /// </summary>
    /// <returns>ゲーム終了時は true</returns>
    public bool IsGameOver() => _isGameOver;

    // ----------------------
    // プライベートメソッド
    // ----------------------

    /// <summary>
    /// 毎フレーム呼ばれる更新処理。
    /// プレイヤーの入力・ターン処理・ゲーム終了判定を行う。
    /// </summary>
    private void Update()
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
                        // プレイヤーを交代
                        _playerSelector = !_playerSelector;
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

    /// <summary>
    /// 入力を取得する（左クリックが押されたかどうか）。
    /// </summary>
    /// <returns>クリックされた場合は true</returns>
    private bool getInput()
    {
        return Input.GetMouseButtonDown(0); // 0 は左クリック
    }

    /// <summary>
    /// 現在のプレイヤーのコイン面（黒 or 白）を取得。
    /// </summary>
    /// <returns>現在のプレイヤーの CoinFace</returns>
    private CoinFace getFace()
    {
        return _playerSelector ? CoinFace.white : CoinFace.black;
    }
}