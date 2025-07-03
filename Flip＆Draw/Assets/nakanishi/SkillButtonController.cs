using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector;
    [SerializeField] private Button skillButton;
    [SerializeField] private int usableTurn = 3;
    [SerializeField] private bool isPlayerCard = true; // true = プレイヤー用, false = 相手用

    private bool isSkillUsed = false;

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();
        bool isPlayerTurn = gameDirector.IsPlayerTurn();

        // 自分のターンかどうかをチェック
        bool isMyTurn = (isPlayerCard == isPlayerTurn);

        // 使用可能条件
        bool canUse = currentTurn >= usableTurn && !isSkillUsed && isMyTurn;

        skillButton.interactable = canUse;
    }

    public void OnSkillUsed()
    {
        isSkillUsed = true;
        skillButton.interactable = false;
    }
}
