using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
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
        int pieceCount = gameDirector.GetPieceCount(); // �Ֆʂ̃R�}�����擾���郁�\�b�h���Ă�
        skillButton.interactable = !isSkillUsed && (pieceCount >= 10); // 10�ȏ�Ȃ牟����
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
