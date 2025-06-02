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
    }

    void UseTurnJumpSkill()
    {
        if (!isSkillUsed)
        {
            isSkillUsed = true;
            gameDirector.UseTurnJumpSkill(); // �^�[���W�����v���������s
            skillButton.interactable = false; // �{�^���𖳌���
            Debug.Log("�^�[���W�����v�X�L�����g�p���܂����I");
        }
        else
        {
            Debug.Log("���̃X�L���͂��łɎg�p�ς݂ł��I");
        }
    }
}