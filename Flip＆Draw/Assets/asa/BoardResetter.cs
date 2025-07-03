using UnityEngine;
using UnityEngine.UI;

public class BoardResetter : MonoBehaviour
{
    [SerializeField] private GameDirector _gameDirector;
    [SerializeField] private Board _board;

    // ボタンにアタッチしておく
    [SerializeField] private Button _resetButton;

    private GameObject _blackCoinPrefab;
    private GameObject _whiteCoinPrefab;

    private void Awake()
    {
        // プレハブはResourcesからロードするか、
        // もしあればインスペクターからセットするのが良いです。
        _blackCoinPrefab = Resources.Load<GameObject>("Prefabs/BlackCoin");
        _whiteCoinPrefab = Resources.Load<GameObject>("Prefabs/WhiteCoin");

        if (_resetButton != null)
        {
            _resetButton.onClick.AddListener(ResetBoardAndGame);
        }
    }

    private void ResetBoardAndGame()
    {
        // 既存コインを全部削除
        DeleteAllCoins();

        // ゲーム状態をリセット(GameDirectorに処理を任せる)
        _gameDirector.ResetGameState();

        // 盤面初期状態にコインを置く
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
        // 盤面の初期4枚配置の位置はBoardクラスか自分で管理してください。
        // ここでは例として中央4マスを仮に指定

        Vector3[] initialPositions = new Vector3[]
        {
            new Vector3(3, 0, 3), // 黒
            new Vector3(4, 0, 4), // 黒
            new Vector3(3, 0, 4), // 白
            new Vector3(4, 0, 3), // 白
        };

        // 黒コイン（先手）
        Instantiate(_blackCoinPrefab, initialPositions[0], Quaternion.identity);
        Instantiate(_blackCoinPrefab, initialPositions[1], Quaternion.identity);

        // 白コイン
        Instantiate(_whiteCoinPrefab, initialPositions[2], Quaternion.identity);
        Instantiate(_whiteCoinPrefab, initialPositions[3], Quaternion.identity);
    }
}
