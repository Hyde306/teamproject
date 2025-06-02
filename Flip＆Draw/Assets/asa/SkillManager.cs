using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Button skillButton;
    private bool isSkillUsed = false;
    public GameDirector gameDirector; // GameDirectorを参照

    void Start()
    {
        skillButton.onClick.AddListener(UseTurnJumpSkill);
    }

    void UseTurnJumpSkill()
    {
        if (!isSkillUsed)
        {
            isSkillUsed = true;
            gameDirector.UseTurnJumpSkill(); // ターンジャンプ処理を実行
            skillButton.interactable = false; // ボタンを無効化
            Debug.Log("ターンジャンプスキルを使用しました！");
        }
        else
        {
            Debug.Log("このスキルはすでに使用済みです！");
        }
    }
}