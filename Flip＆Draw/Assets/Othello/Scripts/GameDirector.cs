﻿using UnityEngine;

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

    // ゲームが終了しているかどうかを取得する。
    // <returns>ゲーム終了時は true</returns>

    public bool IsGameOver() => _isGameOver;

    // 毎フレーム呼ばれる更新処理。
    // プiレイヤーの入力・ターン処理・ゲーム終了判定を行う。

    public bool IsPlayerTurn()
    {
        return !_playerSelector; // false = 黒 (プレイヤー), true = 白 (相手)
    }

    public int GetPieceCount()
    {
        return FindObjectsOfType<Piece>().Length; // "Piece" タグを使わずにオブジェクト数を取得
    }

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

    // ターンジャンプスキルを使用して、相手のターンをスキップする。
    public void UseTurnJumpSkill()
    {
        if (!_isGameOver)
        {
            // (1) スキップ前にマーカーとキャッシュを削除
            ClearMarkers();
            _board.ClearCachedPoints(); // キャッシュクリアを追加

            // (2) 相手のターンをスキップ
            _playerSelector = !_playerSelector;
            Debug.Log("ターンジャンプスキルを使用！相手のターンをスキップしました。");

            // (3) 再度マーカーを削除
            ClearMarkers();

            // (4) 配置可能位置を更新
            _board.UpdateEligiblePositions(getFace());
        }
    }

    private void ClearMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("EligibleMarker");

        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        }
    }

    // 入力を取得する（左クリックが押されたかどうか）。
    // <returns>クリックされた場合は true</returns>
    private bool getInput()
    {
        return Input.GetMouseButtonDown(0); // 0 は左クリック
    }

    // 現在のプレイヤーのコイン面（黒 or 白）を取得
    // <returns>現在のプレイヤーの CoinFace</returns>
    private CoinFace getFace()
    {
        return _playerSelector ? CoinFace.white : CoinFace.black;
    }
}