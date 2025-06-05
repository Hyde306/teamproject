using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 特定のボタンを右クリックすると指定された画像を表示するスクリプト。
/// このスクリプトはボタンのGameObjectにアタッチしてください。
/// </summary>
public class cardtextcheck : MonoBehaviour, IPointerClickHandler
{
    // 表示させたいImage（Inspectorで設定）
    public Image targetImage;

    // マウスクリックイベント処理
    public void OnPointerClick(PointerEventData eventData)
    {
        // 右クリックが押された場合
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (targetImage != null)
            {
                // Imageを表示する（必要なら切り替えも可能）
                //targetImage.gameObject.SetActive(true);
                targetImage.gameObject.SetActive(!targetImage.gameObject.activeSelf); // ← 切り替えたいときはこちら
            }
        }
    }
}