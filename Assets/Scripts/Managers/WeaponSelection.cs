using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField]private BaseWeapon currentWeapon;
    [SerializeField]private WeaponHolder playerWeaponHolder;

    private int weaponIndex;

    [SerializeField]private GameObject[] projectiles;


    private void Awake()
    {
        Time.timeScale = 1;
        weaponIndex = PlayerDataManager.Instance.currentWeapon;

        switch (weaponIndex)
        {
                case 0:
                {
                    SelectBallisticWeapon();
                }
                break;
                case 1:
                {
                    SelectLaserWeapon();
                }
                break;
                case 2:
                {
                    SelectRocketWeapon();
                }
                break ;
        }

        //if (PlayerDataManager.Instance.currentWeapon == 0)
        //{
        //    SelectBallisticWeapon();
        //}
        //else if(PlayerDataManager.Instance.currentWeapon == 1)
        //{
        //    SelectLaserWeapon();
        //}
        //else if(PlayerDataManager.Instance.currentWeapon == 2)
        //{
        //    SelectRocketWeapon();
        //}
        
    }


    public void SelectBallisticWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<BallisticWeapon>();
        playerWeaponHolder.SetProjectile(projectiles[0]);

        currentWeapon = playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>();
        playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>().Initialize();



        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectLaserWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<LaserWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<LaserWeapon>();
        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectRocketWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<RocketWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<RocketWeapon>();
        currentWeapon.Initialize();
        playerWeaponHolder.SetProjectile(projectiles[1]);
        
        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
    }


}
