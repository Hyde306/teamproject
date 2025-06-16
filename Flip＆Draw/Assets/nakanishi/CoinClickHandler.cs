
using UnityEngine;

/// <summary>
/// Coin�I�u�W�F�N�g���N���b�N�����Ƃ��ɔ��]�������Ăяo���X�N���v�g�B
/// </summary>
[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Collider2D))]
public class CoinClickHandler : MonoBehaviour
{
    private Coin _coin;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
    }

    private void OnMouseDown()
    {
        _coin.FlipFace();
    }
}
