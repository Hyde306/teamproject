using UnityEngine;
using UnityEngine.UI;

public class Black_Skip : MonoBehaviour
{
    public Button skillButton;
    private bool isSkillUsed = false;
    public GameDirector gameDirector; // GameDirector���Q��

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
        int pieceCount = gameDirector.GetPieceCount(); // �Ֆʂ̃R�}�����擾
        bool isPlayerTurn = gameDirector.IsPlayerTurn(); // �v���C���[�̃^�[�����ǂ������m�F
        skillButton.interactable = !isPlayerTurn && !isSkillUsed && (pieceCount >= 11);
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