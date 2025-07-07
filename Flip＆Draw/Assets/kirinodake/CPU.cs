using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    [SerializeField] private Board _board;

    [SerializeField] private GameDirector gameDirector; // ゲームの進行状況を管理する GameDirector への参照

    private Coin _coin;

    public static bool cpumove;

    // Start is called before the first frame update
    void Start()
    {
        _coin = GetComponent<Coin>();
        _board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlayerTurn = gameDirector.IsPlayerTurn();     // 現在がプレイヤーのターンかどうか

        if (cpumove)
        {
            _board.PlaceCoinOnBoard(gameDirector.getFace());

            if (!(!gameDirector.IsPlayerTurn())) // 自分のターン＝白ターンかどうか
            {
                _board.updateCoinCaptures();
            }

            _coin.FlipFace();//ひっくり返す

            GameObject[] markers = GameObject.FindGameObjectsWithTag("EligibleMarker");
            foreach (GameObject marker in markers)
            {
                Destroy(marker);
            }

            //キャッシュクリア
            if (_board != null)
            {
                _board.ClearCachedPoints();
            }

            cpumove = false;
        }
    }
}
