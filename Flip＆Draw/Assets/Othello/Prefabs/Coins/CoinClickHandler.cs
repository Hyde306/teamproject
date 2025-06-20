using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Collider2D))]
public class CoinClickHandler : MonoBehaviour
{
    private Coin _coin;
    public bool can_change;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
        can_change = false; // ������Ԃł͖���
    }

    public void EnableHandler() // UI�{�^������Ăяo��
    {
        can_change = true;
    }

    private void OnMouseDown()
    {
        if (can_change)
        {
            _coin.FlipFace();
            can_change = false;

            // ���̃R�C���̑I����Ԃ�����
            CoinClickHandler[] allHandlers = FindObjectsOfType<CoinClickHandler>();
            foreach (CoinClickHandler handler in allHandlers)
            {
                if (handler != this)
                {
                    handler.can_change = false;
                }
            }

            // �}�[�J�[�폜�ƍĔz�u
            GameDirector director = FindObjectOfType<GameDirector>();
            Board board = director.GetComponent<Board>();

            if (board != null)
            {
                // �L���b�V�����N���A
                board.ClearCachedPoints();

                // �}�[�J�[�폜
                board.clearEligibleMarkers();

                // ���݂̃v���C���[�̖ʂ��擾
                CoinFace currentFace = director.IsPlayerTurn() ? CoinFace.black : CoinFace.white;

                // �z�u�\�ʒu���X�V�i�����Ń}�[�J�[�ĕ`�悳���j
                board.UpdateEligiblePositions(currentFace);
            }
        }
    }
}