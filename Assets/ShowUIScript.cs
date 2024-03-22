using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUIScript : MonoBehaviour
{
    public Text gemText;
    public GameObject UI;

    private void Start()
    {
        gemText.text = PlayerDataManager.Instance.GetPlayerCoins().ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        UI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }

    public void BuyBomb()
    {
        if (PlayerDataManager.Instance.GetPlayerCoins() >= 5)
        {
            PlayerDataManager.Instance.DeductCoins(5);
            UI.SetActive(false);
            PlayerDataManager.Instance.bomb = 1;
            gemText.text = PlayerDataManager.Instance.GetPlayerCoins().ToString();
        }
    }
}
