using UnityEngine;
using UnityEngine.UI;

public class OthelloSpecialMove : MonoBehaviour
{
    public Button specialButton;
    private Board board; // �I�Z���̔ՖʊǗ��N���X

    void Start()
    {
        specialButton.onClick.AddListener(ChangeOpponentPiece);
        board = FindObjectOfType<Board>(); // �ՖʊǗ��N���X���擾
    }

    void ChangeOpponentPiece()
    {
        Debug.Log("����{�^����������܂����I");
        
        // ����̃R�}���擾�i�����ł̓����_���ɑI���j
        OthelloCell[] opponentCells = board.GetOpponentCells();
        if (opponentCells.Length > 0)
        {
            OthelloCell selectedCell = opponentCells[Random.Range(0, opponentCells.Length)];
            selectedCell.OwnerID = board.CurrentTurn; // �����̃R�}�ɕύX
            Debug.Log($"�R�}�ύX: {selectedCell.Location}");
        }
    }
}