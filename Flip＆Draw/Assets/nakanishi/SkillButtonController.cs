using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector; // �Q�[���̐i�s�󋵂��Ǘ����� GameDirector �ւ̎Q��
    [SerializeField] private Button skillButton; // �X�L���{�^���� UI �v�f
    [SerializeField] private int usableTurn = 3; // �X�L�����g�p�\�ɂȂ�^�[����
    [SerializeField] private bool isPlayerCard = true; // true = �v���C���[�p, false = ����p

    // �X�L�������łɎg�p���ꂽ���ǂ����������t���O
    private bool isSkillUsed = false;

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();    // ���݂̃^�[�������擾
        bool isPlayerTurn = gameDirector.IsPlayerTurn(); // ���݂��v���C���[�̃^�[�����ǂ������擾
        bool isMyTurn = (isPlayerCard == isPlayerTurn); // ���̃{�^���������̃^�[���ɑΉ����Ă��邩�𔻒�
        bool canUse = currentTurn >= usableTurn && !isSkillUsed && isMyTurn;// �X�L�����g�p�\���ǂ����𔻒�
        skillButton.interactable = canUse;// �{�^���̑���ۂ�ݒ�
    }

    // �X�L�����g�p���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OnSkillUsed()
    {
        isSkillUsed = true; // �X�L���g�p�ς݂ɐݒ�
        skillButton.interactable = false; // �{�^���𖳌���
    }
}
