using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnResetController : MonoBehaviour
{
    [SerializeField] private GameDirector _gameDirector;
    [SerializeField] private Board _board;
    [SerializeField] private Button _resetButton;

    // �ŏ��̔Ֆʂɒu���Ă���R�C���̏���ۑ�
    private List<InitialCoinInfo> _initialCoins = new List<InitialCoinInfo>();

    private void Start()
    {
        // �ŏ��̃R�C���̏���ۑ�����
        SaveInitialCoins();

        // �{�^���Ƀ��Z�b�g������o�^
        _resetButton.onClick.AddListener(ResetBoardAndTurn);
    }

    private void SaveInitialCoins()
    {
        _initialCoins.Clear();

        // Board��̑S�R�C����T���ď��ۑ��iGameObject.FindGameObjectsWithTag�g���Ă������j
        var coins = GameObject.FindGameObjectsWithTag("Blackcoin");
        foreach (var c in coins)
        {
            _initialCoins.Add(new InitialCoinInfo(c.transform.position, CoinFace.black));
        }
        coins = GameObject.FindGameObjectsWithTag("Whitecoin");
        foreach (var c in coins)
        {
            _initialCoins.Add(new InitialCoinInfo(c.transform.position, CoinFace.white));
        }
    }

    private void ResetBoardAndTurn()
    {
        // �Ֆʂ̑S�R�C��������
        var allCoins = GameObject.FindGameObjectsWithTag("Blackcoin");
        foreach (var c in allCoins)
        {
            Destroy(c);
        }
        allCoins = GameObject.FindGameObjectsWithTag("Whitecoin");
        foreach (var c in allCoins)
        {
            Destroy(c);
        }

        // �ŏ��ɒu����Ă����R�C�����Đ����iBoard��Coin�̐���������z�����Ď�����Instantiate����j
        foreach (var coinInfo in _initialCoins)
        {
            CreateCoinAtPosition(coinInfo.Position, coinInfo.Face);
        }

        // �^�[���������I�ɍ��v���C���[�̃^�[���ɖ߂��i_playerSelector��private�ŐG��Ȃ��̂ő����GameDirector�Ƀ^�[���������߂Ă��炤�`�Ȃǂ͎g���Ȃ��j
        // �Ȃ̂ł����ł�GameDirector���͐G�炸�A�^�[���֘A�̏����͐V�X�N���v�g���ŊǗ����Ă�������

        Debug.Log("�Ֆʂƃ^�[����������Ԃɖ߂��܂���");
    }

    // �R�C���𐶐����鏈���iBoard��GameDirector�Ɉˑ����Ȃ��Œ���̎�����j
    private void CreateCoinAtPosition(Vector3 position, CoinFace face)
    {
        // ������Coin�v���n�u��Resources������ǂݍ����Instantiate���Aface�ɉ����ĐF��ݒ肷�鏈��������
        // ��iCoinPrefab��Inspector�ŃA�T�C�����Ă���ꍇ�j�F

        GameObject coinPrefab = null;
        if (face == CoinFace.black)
        {
            coinPrefab = Resources.Load<GameObject>("Prefabs/BlackCoin"); // �v���n�u���͓K�X�ύX
        }
        else
        {
            coinPrefab = Resources.Load<GameObject>("Prefabs/WhiteCoin");
        }

        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("�R�C���̃v���n�u��������܂���");
        }
    }

    // �ŏ��̃R�C������ێ����邽�߂̃N���X
    private class InitialCoinInfo
    {
        public Vector3 Position;
        public CoinFace Face;

        public InitialCoinInfo(Vector3 pos, CoinFace face)
        {
            Position = pos;
            Face = face;
        }
    }
}
