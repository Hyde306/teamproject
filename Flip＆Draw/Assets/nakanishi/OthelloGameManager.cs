using UnityEngine;

public class OthelloGameManager : MonoBehaviour
{
    public Sprite whitePieceSprite; // ���̃X�v���C�g���Z�b�g

    void SelectOpponentPiece()
    {
        GameObject[] opponentPieces = GameObject.FindGameObjectsWithTag("BlackPiece");

        if (opponentPieces.Length > 0)
        {
            // �����_���ő���̃R�}��I��
            GameObject selectedPiece = opponentPieces[Random.Range(0, opponentPieces.Length)];
            ChangePiece(selectedPiece);
        }
    }

    void ChangePiece(GameObject piece)
    {
        SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
        sr.sprite = whitePieceSprite; // ���̃X�v���C�g�ɕύX
        piece.tag = "WhitePiece"; // �^�O��ύX
    }
}