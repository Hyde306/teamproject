using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector; // �Q�[���̐i�s�󋵂��Ǘ����� GameDirector �ւ̎Q��
    [SerializeField] private Button skillButton;        // �X�L���{�^���� UI �v�f
    [SerializeField] private int usableTurn = 3;        // �X�L�����g�p�\�ɂȂ�^�[����
    [SerializeField] private int maxUses = 3;           // �X�L���̍ő�g�p��
    [SerializeField] private bool isPlayerCard = true;  // ���̃{�^�����v���C���[�p���ǂ����ifalse �Ȃ瑊��p�j

    private int currentUses = 0;        // ���݂̎g�p��
    private int lastUsedTurn = -1;      // �Ō�ɃX�L�����g�p�����^�[���i�����l�͖��g�p�j

    void Start()
    {
        // �{�^�����N���b�N���ꂽ�Ƃ��̃C�x���g��o�^
        skillButton.onClick.AddListener(OnSkillButtonClicked);
    }

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();     // ���݂̃^�[�������擾
        bool isPlayerTurn = gameDirector.IsPlayerTurn();     // ���݂��v���C���[�̃^�[�����ǂ���
        bool isMyTurn = (isPlayerCard == isPlayerTurn);      // ���̃{�^���������̃^�[���ɑΉ����Ă��邩

        // ���̃^�[���ł��łɃX�L�����g���Ă��邩�ǂ���
        bool alreadyUsedThisTurn = (lastUsedTurn == currentTurn);

        // �X�L�����g�p�\���ǂ����𔻒�
        bool canUse = currentTurn >= usableTurn &&           // �g�p�\�^�[���ɒB���Ă���
                      currentUses < maxUses &&               // �g�p�񐔂̏���ɒB���Ă��Ȃ�
                      isMyTurn &&                            // �����̃^�[���ł���
                      !alreadyUsedThisTurn;                  // ���̃^�[���ł܂��g���Ă��Ȃ�

        // �{�^���̑���ۂ�ݒ�
        skillButton.interactable = canUse;
    }

    // �X�L�����g�p���ꂽ���Ƃ��L�^����i�O������Ăяo���j
    public void MarkSkillAsUsed()
    {
        int currentTurn = gameDirector.GetCurrentTurn();

        // �����^�[����2��ȏ�g���Ȃ��悤�ɂ���
        if (lastUsedTurn == currentTurn) return;

        currentUses++;               // �g�p�񐔂��J�E���g
        lastUsedTurn = currentTurn; // �Ō�Ɏg�p�����^�[�����L�^

        // �g�p�񐔂̏���ɒB������{�^���𖳌���
        if (currentUses >= maxUses)
        {
            skillButton.interactable = false;
        }
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��̏����i�K�v�ɉ����ĊO�������ƘA�g�j
    private void OnSkillButtonClicked()
    {
        MarkSkillAsUsed(); // �X�L���g�p���L�^�i���ۂ̃X�L�����ʂ͊O���ŏ����j
    }
}
