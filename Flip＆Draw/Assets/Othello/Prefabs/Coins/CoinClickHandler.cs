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
        if (can_change) // �X�N���v�g���L���Ȃ珈�������s
        {
            _coin.FlipFace();
            can_change = false; // ���s��ɖ�����
        }
    }
}