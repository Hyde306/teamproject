using UnityEngine;

public class OthelloGameManager : MonoBehaviour
{
    public Sprite whitePieceSprite; // 白のスプライトをセット

    void SelectOpponentPiece()
    {
        GameObject[] opponentPieces = GameObject.FindGameObjectsWithTag("BlackPiece");

        if (opponentPieces.Length > 0)
        {
            // ランダムで相手のコマを選択
            GameObject selectedPiece = opponentPieces[Random.Range(0, opponentPieces.Length)];
            ChangePiece(selectedPiece);
        }
    }

    void ChangePiece(GameObject piece)
    {
        SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
        sr.sprite = whitePieceSprite; // 白のスプライトに変更
        piece.tag = "WhitePiece"; // タグを変更
    }
}