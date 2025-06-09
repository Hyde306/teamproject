using Lacobus.Animation;
using Lacobus.Grid;// �O���b�h�V�X�e�����g�p
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuPlayer : MonoBehaviour
{
    // ���݂̃R�C���̖ʁi�� or ���j
    [SerializeField] private CoinFace _currentFace;

    // �Ֆʂ̃T�C�Y�i��F8x8�j
    private int boardSize = 8;

    // �Ֆʂ̏�Ԃ�\���i0=�󂫁A1=�v���C���[�A2=CPU�Ȃǁj
    private int[,] board;

    void Start()
    {
        board = new int[boardSize, boardSize];
        // �����ŏ����ՖʃZ�b�g�A�b�v�Ȃ�
    }

    // CPU�̃^�[���ŋ�������_���ɒu�����\�b�h
    public void PlayRandom()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // �ՖʑS�̂��`�F�b�N���āA�u����ꏊ�����X�g�ɏW�߂�
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

        // �u����ꏊ���Ȃ���Ή������Ȃ�
        if (validMoves.Count == 0)
        {
            Debug.Log("CPU�͒u����ꏊ������܂���");
            return;
        }

        // �����_����1�����I��
        int index = Random.Range(0, validMoves.Count);
        Vector2Int move = validMoves[index];

        // ���u�������i�����̓Q�[���ɍ��킹�Ď����j
        PlacePiece(move.x, move.y);

        Debug.Log($"CPU�� ({move.x}, {move.y}) �ɋ��u���܂���");
    }

    // �����Ɂu���̃}�X�ɒu���邩�v�̔��������
    private bool CanPlaceAt(int x, int y)
    {
        // �󂫃}�X���ǂ�����������i�{���̓I�Z�����[���Ŕ���j
        return board[x, y] == 0;
    }

    // ���u�������̗�
    private void PlacePiece(int x, int y)
    {
        // 2��CPU�̋�Ƃ���
        board[x, y] = 2;
        // �Ђ�����Ԃ������Ȃǂ������ɏ���

        // ���݂̖ʂ�؂�ւ���
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
