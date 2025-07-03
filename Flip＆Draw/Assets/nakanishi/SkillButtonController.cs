using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector; // GameDirectorへの参照
    [SerializeField] private Button skillButton;        // スキルボタン
    [SerializeField] private int usableTurn = 3;        // 使用可能になるターン

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();

        // 指定ターン以降ならボタンを有効化
        skillButton.interactable = currentTurn >= usableTurn;
    }
}
