using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    public string coinTag = "Coin"; // Unity�Őݒ肵���^�O��

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

        // �}�[�J�[�Ĕz�u������ǉ�
        GameDirector director = FindObjectOfType<GameDirector>();
        Board board = director.GetComponent<Board>();

        if (board != null)
        {
            board.ClearCachedPoints();
            board.clearEligibleMarkers();

            CoinFace currentFace = director.IsPlayerTurn() ? CoinFace.black : CoinFace.white;
            board.UpdateEligiblePositions(currentFace); // ����Ń}�[�J�[���ĕ`�悳���
        }
    }

}
