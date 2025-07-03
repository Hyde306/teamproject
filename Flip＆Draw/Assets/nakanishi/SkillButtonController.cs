using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector;
    [SerializeField] private Button skillButton;
    [SerializeField] private int usableTurn = 3;
    [SerializeField] private bool isPlayerCard = true; // true = �v���C���[�p, false = ����p

    private bool isSkillUsed = false;

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();
        bool isPlayerTurn = gameDirector.IsPlayerTurn();

        // �����̃^�[�����ǂ������`�F�b�N
        bool isMyTurn = (isPlayerCard == isPlayerTurn);

        // �g�p�\����
        bool canUse = currentTurn >= usableTurn && !isSkillUsed && isMyTurn;

        skillButton.interactable = canUse;
    }

    public void OnSkillUsed()
    {
        isSkillUsed = true;
        skillButton.interactable = false;
    }
}
