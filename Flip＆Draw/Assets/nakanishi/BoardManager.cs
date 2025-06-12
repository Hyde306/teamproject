using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    private bool isSelecting = false;

    void Awake()
    {
        Instance = this;
    }

    public void ActivateSelectMode()
    {
        isSelecting = true;
        Debug.Log(GameManager.Instance.GetCurrentPlayer() == CoinFace.black ? "���̃^�[�� - �R�}�I���J�n" : "���̃^�[�� - �R�}�I���J�n");
    }

    public void aaa()
    {
        if (isSelecting && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("�N���b�N���W: " + mousePos);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null)
            {
                Debug.Log("�q�b�g�����I�u�W�F�N�g: " + hit.gameObject.name);

                if (hit.CompareTag("OpponentPiece") || hit.CompareTag("PlayerPiece"))
                {
                    Coin coin = hit.GetComponent<Coin>();
                    if (coin != null)
                    {
                        Debug.Log("�R�}�̔��]�����s");
                        coin.FlipFace(); // �R�}�𔽓]
                        Debug.Log(GameManager.Instance.GetCurrentPlayer() == CoinFace.black ? "�����R�}��ύX�I" : "�����R�}��ύX�I");
                    }

                    isSelecting = false;
                    Debug.Log("�^�[���I�����������s");
                    GameManager.Instance.EndTurn(); // �^�[�����I�����A���
                }
            }
        }
    }
}