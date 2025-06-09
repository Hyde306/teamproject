using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private CoinFace currentPlayer = CoinFace.black; // ���v���C���[����X�^�[�g

    void Awake()
    {
        Instance = this;
    }

    public void EndTurn()
    {
        currentPlayer = currentPlayer == CoinFace.black ? CoinFace.white : CoinFace.black; // �^�[���؂�ւ�
        Debug.Log(currentPlayer == CoinFace.black ? "���v���C���[�̃^�[��" : "���v���C���[�̃^�[��");
    }

    public CoinFace GetCurrentPlayer()
    {
        return currentPlayer;
    }
}