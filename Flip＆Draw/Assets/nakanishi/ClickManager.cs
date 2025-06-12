using System.Diagnostics;

public class ClickManager : MonoBehaviour
{
    public Button activateButton;
    public GameObject clickableImage;  // 対象の画像
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
                Debug.Log("画像がクリックされました！");
                // ここに画像クリック時の処理を記述
                isClickable = false; // クリック後、無効にしたい場合
            }
        }
    }
}