using UnityEngine;
using UnityEngine.UI;
using TMPro; // TMPを使うために追加

public class Black_Skip : MonoBehaviour
{
    public Button skillButton;
    public TMP_Text countdownText; // TextMeshPro用のテキスト
    private bool isSkillUsed = false;//boolでtrue/false判断
    public GameDirector gameDirector; // GameDirectorを参照
    private int remainingTurns = 15; // 初期の残りターン数

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
        int currentTurn = gameDirector.GetCurrentTurn(); // 現在のターン数を取得
        remainingTurns = Mathf.Max(0, 17 - currentTurn); // 使用可能までの残りターンを計算
        int pieceCount = gameDirector.GetPieceCount(); // 盤面のコマ数を取得

        bool isPlayerTurn = gameDirector.IsPlayerTurn(); // プレイヤーのターンかどうかを確認
        skillButton.interactable = !isPlayerTurn && !isSkillUsed && (pieceCount >= 20);

        countdownText.text = "remaining turns \n\n         <size=150%>" + remainingTurns + "</size>";
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