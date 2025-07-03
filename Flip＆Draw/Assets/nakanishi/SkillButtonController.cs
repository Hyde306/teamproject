using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector; // GameDirector�ւ̎Q��
    [SerializeField] private Button skillButton;        // �X�L���{�^��
    [SerializeField] private int usableTurn = 3;        // �g�p�\�ɂȂ�^�[��

    void Update()
    {
        int currentTurn = gameDirector.GetCurrentTurn();

        // �w��^�[���ȍ~�Ȃ�{�^����L����
        skillButton.interactable = currentTurn >= usableTurn;
    }
}
