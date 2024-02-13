using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponUpgradePresenter : MonoBehaviour
{

    public WeaponUpgradeView view;
    public WeaponUpgradeModel model;

    public int weaponIndex;
    
   

    public void SetActiveWeapon(int weaponIndex)
    {
        view.weaponUpgradePopUp.SetActive(true);
        this.weaponIndex = weaponIndex;
        Time.timeScale = 0;
    }

    public void SetUpgradeUI()
    {

    }


    public void UpgradeSelectedWeapon()
    {

        if (PlayerDataManager.Instance.premiumCoins >= model.upgradeCosts[weaponIndex])
        {
            if (model.weaponDatas[weaponIndex].weaponLevel == 6)
                return;

            model.weaponDatas[weaponIndex].weaponLevel++;
            Debug.Log("Weapon Upgrade");

        }

    }

    public void ClosePanel()
    {
        view.weaponUpgradePopUp.SetActive(false);
        Time.timeScale = 1;
    }

    public void EnterGame()
    {
        PlayerDataManager.Instance.currentWeapon = weaponIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game 1");
        
    }


}
