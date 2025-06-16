using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CoinコンポーネントとCollider2DコンポーネントがこのGameObjectに必要であることを指定
[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Collider2D))]
public class coinretu : MonoBehaviour
{
// Coinコンポーネントへの参照を保持するための変数
    private Coin _coin;
    private float _timer;
    private float _flipInterval;


    // ゲーム開始時またはオブジェクト生成時に呼び出される
    private void Awake()
    {
        // 同じGameObjectにアタッチされているCoinコンポーネントを取得
        _coin = GetComponent<Coin>();

        SetRandomInterval(); // 初期のランダム間隔を設定
    }

    // 毎フレーム呼び出される（今回は未使用）

    void Update()
    {
        _timer += Time.deltaTime;

        // 一定時間経過したらコインを反転
        if (_timer >= _flipInterval)
        {
            _coin.FlipFace();
            _timer = 0f;
            SetRandomInterval(); // 次の反転までのランダム時間を設定
        }
    }

    private void SetRandomInterval()
    {
        // 1秒〜3秒の間でランダムな時間を設定
        _flipInterval = Random.Range(1f, 3f);
    }

    private void OnMouseDown()
    {
        _coin.FlipFace(); // マウスクリックでも反転
    }

}
