using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector; // ゲームの進行状況を管理する GameDirector への参照
    [SerializeField] private Button skillButton;        // スキルボタンの UI 要素
    [SerializeField] private int usableTurn = 3;        // スキルが使用可能になるターン数
    [SerializeField] private int maxUses = 3;           // スキルの最大使用回数
    [SerializeField] private bool isPlayerCard = true;  // このボタンがプレイヤー用かどうか（false なら相手用）

    private int currentUses = 0;        // 現在の使用回数
    private int lastUsedTurn = -1;      // 最後にスキルを使用したターン（初期値は未使用）

    void Start()
    {
        // ボタンがクリックされたときのイベントを登録
        skillButton.onClick.AddListener(OnSkillButtonClicked);
    }

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();     // 現在のターン数を取得
        bool isPlayerTurn = gameDirector.IsPlayerTurn();     // 現在がプレイヤーのターンかどうか
        bool isMyTurn = (isPlayerCard == isPlayerTurn);      // このボタンが自分のターンに対応しているか

        // このターンですでにスキルを使っているかどうか
        bool alreadyUsedThisTurn = (lastUsedTurn == currentTurn);

        // スキルが使用可能かどうかを判定
        bool canUse = currentTurn >= usableTurn &&           // 使用可能ターンに達している
                      currentUses < maxUses &&               // 使用回数の上限に達していない
                      isMyTurn &&                            // 自分のターンである
                      !alreadyUsedThisTurn;                  // このターンでまだ使っていない

        // ボタンの操作可否を設定
        skillButton.interactable = canUse;
    }

    // スキルが使用されたことを記録する（外部から呼び出す）
    public void MarkSkillAsUsed()
    {
        int currentTurn = gameDirector.GetCurrentTurn();

        // 同じターンで2回以上使えないようにする
        if (lastUsedTurn == currentTurn) return;

        currentUses++;               // 使用回数をカウント
        lastUsedTurn = currentTurn; // 最後に使用したターンを記録

        // 使用回数の上限に達したらボタンを無効化
        if (currentUses >= maxUses)
        {
            skillButton.interactable = false;
        }
    }

    // ボタンがクリックされたときの処理（必要に応じて外部処理と連携）
    private void OnSkillButtonClicked()
    {
        MarkSkillAsUsed(); // スキル使用を記録（実際のスキル効果は外部で処理）
    }
}
