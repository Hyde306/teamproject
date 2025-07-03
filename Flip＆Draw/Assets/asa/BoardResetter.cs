using UnityEngine;
using UnityEngine.UI;

public class BoardResetter : MonoBehaviour
{
    [SerializeField] private GameDirector _gameDirector;
    [SerializeField] private Board _board;

    // �{�^���ɃA�^�b�`���Ă���
    [SerializeField] private Button _resetButton;

    private GameObject _blackCoinPrefab;
    private GameObject _whiteCoinPrefab;

    private void Awake()
    {
        // �v���n�u��Resources���烍�[�h���邩�A
        // ��������΃C���X�y�N�^�[����Z�b�g����̂��ǂ��ł��B
        _blackCoinPrefab = Resources.Load<GameObject>("Prefabs/BlackCoin");
        _whiteCoinPrefab = Resources.Load<GameObject>("Prefabs/WhiteCoin");

        if (_resetButton != null)
        {
            _resetButton.onClick.AddListener(ResetBoardAndGame);
        }
    }

    private void ResetBoardAndGame()
    {
        // �����R�C����S���폜
        DeleteAllCoins();

        // �Q�[����Ԃ����Z�b�g(GameDirector�ɏ�����C����)
        _gameDirector.ResetGameState();

        // �Ֆʏ�����ԂɃR�C����u��
        PlaceInitialCoins();
    }

    private void DeleteAllCoins()
    {
        GameObject[] blackCoins = GameObject.FindGameObjectsWithTag("Blackcoin");
        GameObject[] whiteCoins = GameObject.FindGameObjectsWithTag("Whitecoin");

        foreach (var coin in blackCoins) Destroy(coin);
        foreach (var coin in whiteCoins) Destroy(coin);
    }

    private void PlaceInitialCoins()
    {
        // �Ֆʂ̏���4���z�u�̈ʒu��Board�N���X�������ŊǗ����Ă��������B
        // �����ł͗�Ƃ��Ē���4�}�X�����Ɏw��

        Vector3[] initialPositions = new Vector3[]
        {
            new Vector3(3, 0, 3), // ��
            new Vector3(4, 0, 4), // ��
            new Vector3(3, 0, 4), // ��
            new Vector3(4, 0, 3), // ��
        };

        // ���R�C���i���j
        Instantiate(_blackCoinPrefab, initialPositions[0], Quaternion.identity);
        Instantiate(_blackCoinPrefab, initialPositions[1], Quaternion.identity);

        // ���R�C��
        Instantiate(_whiteCoinPrefab, initialPositions[2], Quaternion.identity);
        Instantiate(_whiteCoinPrefab, initialPositions[3], Quaternion.identity);
    }
}
