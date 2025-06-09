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
        UpdateButtonState(); // 最初の状態をチェック
    }

    void Update()
    {
        UpdateButtonState(); // 毎フレーム、ボタンの状態を更新
    }

    void UpdateButtonState()
    {
        int pieceCount = gameDirector.GetPieceCount(); // 盤面のコマ数を取得するメソッドを呼ぶ
        skillButton.interactable = !isSkillUsed && (pieceCount >= 10); // 10個以上なら押せる
    }

    void UseTurnJumpSkill()
    {
        if (!isSkillUsed)
        {
            isSkillUsed = true;

            gameDirector.UseTurnJumpSkill(); // ターンジャンプ処理を実行

            Debug.Log("ターンジャンプスキルを使用しました！");

            UpdateButtonState(); // スキル使用後、ボタンの状態を更新
        }

        else
        {
            Debug.Log("このスキルはすでに使用済みです！");
        }
    }
}
