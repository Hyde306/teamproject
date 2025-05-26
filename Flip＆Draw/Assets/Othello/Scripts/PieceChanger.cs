using UnityEngine;

public class OthelloBoard : MonoBehaviour
{
    public int[,] board = new int[8, 8]; // �Ֆʂ�2D�z��ŊǗ� (0:��, 1:��, 2:��)

    public void ChangePiece(int x, int y, int playerColor)
    {
        if (board[x, y] != 0) // ���ɋ����ꍇ�̂ݕύX�\
        {
            board[x, y] = playerColor; // �w����W�̋���v���C���[�̐F�ɕύX
            Debug.Log($"���ύX���܂���: ({x}, {y}) -> �F {playerColor}");
        }
    }
}