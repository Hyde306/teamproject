using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    public GameDirector gameDirector; // GameDirectorÇéQè∆
    [SerializeField] private Board _board;
    public string coinTag = "Coin"; // UnityÇ≈ê›íËÇµÇΩÉ^ÉOñº

    public void ActivateCoinHandler()
    {
        GameObject[] coinObjects = GameObject.FindGameObjectsWithTag(coinTag);
        foreach (GameObject coinObj in coinObjects)
        {
            CoinClickHandler handler = coinObj.GetComponent<CoinClickHandler>();
            if (handler != null)
            {
                handler.EnableHandler();
            }
        }
    }
}
