using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponUpgradePresenter : MonoBehaviour
{
    public WeaponSelection selection;
    public WeaponUpgradeView view;
    public WeaponUpgradeModel model;


    public void SetActiveWeapon(int weaponIndex)
    {
        model.weaponIndex = weaponIndex;
        view.SetDataToUI();
        view.weaponUpgradePopUp.SetActive(true);
        
        Time.timeScale = 0;
    }


    public void UpgradeSelectedWeapon()
    {

        if (PlayerDataManager.Instance.premiumCoins >= model.upgradeCosts[model.weaponIndex])
        {
            if (model.weaponDatas[model.weaponIndex].weaponLevel == 6)
                return;

            model.weaponDatas[model.weaponIndex].IncreaseWeaponLevel();
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
        PlayerDataManager.Instance.currentWeapon = model.weaponIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game 1");
        
    }


}
