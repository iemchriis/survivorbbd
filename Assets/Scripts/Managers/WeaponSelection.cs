using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField]private BaseWeapon currentWeapon;
    [SerializeField]private WeaponHolder playerWeaponHolder;

    private int weaponIndex;
    [SerializeField]private WeaponDatas[] weaponDatas;  


    public void Initialize()
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
                break;
                case 3:
                {
                    SelectShotgunWeapon();
                }
                break ;
        }

        
    }


    public void SelectBallisticWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<BallisticWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>();
        currentWeapon.weaponData = weaponDatas[0];
        currentWeapon.Initialize();


    
    }

    public void SelectLaserWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<LaserWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<LaserWeapon>();
        currentWeapon.weaponData = weaponDatas[1];
        currentWeapon.Initialize();

    
    }

    public void SelectRocketWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<RocketWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<RocketWeapon>();
        currentWeapon.weaponData = weaponDatas[2];
        currentWeapon.Initialize();

      
    }

    public void SelectShotgunWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<ShotgunWeapon>();
        currentWeapon = (ShotgunWeapon) playerWeaponHolder.gameObject.GetComponent<ShotgunWeapon>();
        currentWeapon.weaponData = weaponDatas[3];
        currentWeapon.Initialize();

       
    }

    void ResumeGame()
    {

    }


}
