using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ����̃{�^�����E�N���b�N����Ǝw�肳�ꂽ�摜��\������X�N���v�g�B
/// ���̃X�N���v�g�̓{�^����GameObject�ɃA�^�b�`���Ă��������B
/// </summary>
public class cardtextcheck : MonoBehaviour, IPointerClickHandler
{
    // �\����������Image�iInspector�Őݒ�j
    public Image targetImage;

    // �}�E�X�N���b�N�C�x���g����
    public void OnPointerClick(PointerEventData eventData)
    {
        // �E�N���b�N�������ꂽ�ꍇ
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (targetImage != null)
            {
                // Image��\������i�K�v�Ȃ�؂�ւ����\�j
                //targetImage.gameObject.SetActive(true);
                targetImage.gameObject.SetActive(!targetImage.gameObject.activeSelf); // �� �؂�ւ������Ƃ��͂�����
            }
        }
    }
}