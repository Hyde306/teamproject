using UnityEngine;
using UnityEngine.UI;
using TMPro; // TMP���g�����߂ɒǉ�

public class Black_Skip : MonoBehaviour
{
    public Button skillButton;
    public TMP_Text countdownText; // TextMeshPro�p�̃e�L�X�g
    private bool isSkillUsed = false;//bool��true/false���f
    public GameDirector gameDirector; // GameDirector���Q��
    private int remainingTurns = 15; // �����̎c��^�[����

    void Start()
    {
        skillButton.onClick.AddListener(UseTurnJumpSkill);
        UpdateButtonState(); // �ŏ��̏�Ԃ��`�F�b�N
    }

    void Update()
    {
        UpdateButtonState(); // ���t���[���A�{�^���̏�Ԃ��X�V
    }

    void UpdateButtonState()
    {
        int currentTurn = gameDirector.GetCurrentTurn(); // ���݂̃^�[�������擾
        remainingTurns = Mathf.Max(0, 17 - currentTurn); // �g�p�\�܂ł̎c��^�[�����v�Z
        int pieceCount = gameDirector.GetPieceCount(); // �Ֆʂ̃R�}�����擾

        bool isPlayerTurn = gameDirector.IsPlayerTurn(); // �v���C���[�̃^�[�����ǂ������m�F
        skillButton.interactable = !isPlayerTurn && !isSkillUsed && (pieceCount >= 20);

        countdownText.text = "remaining turns \n\n         <size=150%>" + remainingTurns + "</size>";
    }

    void UseTurnJumpSkill()
    {
        if (!isSkillUsed)
        {
            isSkillUsed = true;
            gameDirector.UseTurnJumpSkill(); // �^�[���W�����v���������s
            Debug.Log("�^�[���W�����v�X�L�����g�p���܂����I");
            UpdateButtonState(); // �X�L���g�p��A�{�^���̏�Ԃ��X�V
        }
        else
        {
            Debug.Log("���̃X�L���͂��łɎg�p�ς݂ł��I");
        }
    }
}