using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponUpgrade : MonoBehaviour
{
    public GameObject WeaponUpgradePopUp;
    public Image WeaponUpgradeImage;
    public Text weaponUpgradeText;

    public int weaponIndex;
    [SerializeField] private WeaponDatas[] weaponDatas;

    public int[] upgradeCosts;
    public Sprite[] weaponStatsSprite;

    public void SetActiveWeapon(int weaponIndex)
    {
        WeaponUpgradePopUp.SetActive(true);
        this.weaponIndex = weaponIndex;
        Time.timeScale = 0;
    }


    public void UpgradeSelectedWeapon()
    {

        if (PlayerDataManager.Instance.premiumCoins >= upgradeCosts[weaponIndex])
        {
            if (weaponDatas[weaponIndex].weaponLevel == 6)
                return;

            weaponDatas[weaponIndex].weaponLevel++;
            Debug.Log("Weapon Upgrade");

        }

    }

    public void ClosePanel()
    {
        WeaponUpgradePopUp.SetActive(false);
        Time.timeScale = 1;
    }

    public void EnterGame()
    {
        PlayerDataManager.Instance.currentWeapon = weaponIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game 1");
        
    }


}
