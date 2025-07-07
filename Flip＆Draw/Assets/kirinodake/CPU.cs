using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    [SerializeField] private Board _board;

    [SerializeField] private GameDirector gameDirector; // �Q�[���̐i�s�󋵂��Ǘ����� GameDirector �ւ̎Q��

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
        bool isPlayerTurn = gameDirector.IsPlayerTurn();     // ���݂��v���C���[�̃^�[�����ǂ���

        if (cpumove)
        {
            _board.PlaceCoinOnBoard(gameDirector.getFace());

            if (!(!gameDirector.IsPlayerTurn())) // �����̃^�[�������^�[�����ǂ���
            {
                _board.updateCoinCaptures();
            }

            _coin.FlipFace();//�Ђ�����Ԃ�

            GameObject[] markers = GameObject.FindGameObjectsWithTag("EligibleMarker");
            foreach (GameObject marker in markers)
            {
                Destroy(marker);
            }

            //�L���b�V���N���A
            if (_board != null)
            {
                _board.ClearCachedPoints();
            }

            cpumove = false;
        }
    }
}
