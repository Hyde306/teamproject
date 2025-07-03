using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector; // ゲームの進行状況を管理する GameDirector への参照
    [SerializeField] private Button skillButton; // スキルボタンの UI 要素
    [SerializeField] private int usableTurn = 3; // スキルが使用可能になるターン数
    [SerializeField] private bool isPlayerCard = true; // true = プレイヤー用, false = 相手用

    // スキルがすでに使用されたかどうかを示すフラグ
    private bool isSkillUsed = false;

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();    // 現在のターン数を取得
        bool isPlayerTurn = gameDirector.IsPlayerTurn(); // 現在がプレイヤーのターンかどうかを取得
        bool isMyTurn = (isPlayerCard == isPlayerTurn); // このボタンが自分のターンに対応しているかを判定
        bool canUse = currentTurn >= usableTurn && !isSkillUsed && isMyTurn;// スキルが使用可能かどうかを判定
        skillButton.interactable = canUse;// ボタンの操作可否を設定
    }

    // スキルが使用されたときに呼び出されるメソッド
    public void OnSkillUsed()
    {
        isSkillUsed = true; // スキル使用済みに設定
        skillButton.interactable = false; // ボタンを無効化
    }
}
