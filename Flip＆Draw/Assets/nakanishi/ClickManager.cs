using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public Button activateButton;
    public GameObject clickableImage;  // �Ώۂ̉摜
    private bool isClickable = false;

    void Start()
    {
        activateButton.onClick.AddListener(EnableClick);
    }

    void EnableClick()
    {
        isClickable = true;
    }

    void Update()
    {
        if (isClickable && Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(worldPoint);

            if (hit && hit.gameObject == clickableImage)
            {
                UnityEngine.Debug.Log("�摜���N���b�N����܂����I");

                // Coin�R���|�[�l���g���擾���� FlipFace() �����s
                Coin coin = clickableImage.GetComponent<Coin>();
                if (coin != null)
                {
                    coin.FlipFace(); // �R�C���̖ʂ𔽓]
                }
                else
                {
                    UnityEngine.Debug.LogWarning("Coin �R���|�[�l���g��������܂���I");
                }

                //isClickable = false; // �N���b�N��A�����ɂ������ꍇ
            }
        }
    }
}