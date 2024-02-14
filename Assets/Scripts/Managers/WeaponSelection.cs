using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public BaseWeapon currentWeapon;
    [SerializeField]private WeaponHolder playerWeaponHolder;

    private int weaponIndex;
    [SerializeField]private WeaponDatas[] weaponDatas;  


    public void SelectWeapon()
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
        if(currentWeapon == null)
        {
            playerWeaponHolder.gameObject.AddComponent<BallisticWeapon>();
            currentWeapon = playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>();
            currentWeapon.weaponData = weaponDatas[0];
            currentWeapon.Initialize();

        }
        else if (currentWeapon.weaponData != weaponDatas[0])
        {
            Destroy(currentWeapon);
            playerWeaponHolder.gameObject.AddComponent<BallisticWeapon>();
            currentWeapon = playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>();
            currentWeapon.weaponData = weaponDatas[0];
            currentWeapon.Initialize();

        }




    }

    public void SelectLaserWeapon()
    {

        if(currentWeapon == null )
        {
            playerWeaponHolder.gameObject.AddComponent<LaserWeapon>();
            currentWeapon = playerWeaponHolder.gameObject.GetComponent<LaserWeapon>();
            currentWeapon.weaponData = weaponDatas[1];
            currentWeapon.Initialize();
        }
        else if (currentWeapon.weaponData != weaponDatas[1])
        {
            Destroy (currentWeapon);
            playerWeaponHolder.gameObject.AddComponent<LaserWeapon>();
            currentWeapon = playerWeaponHolder.gameObject.GetComponent<LaserWeapon>();
            currentWeapon.weaponData = weaponDatas[1];
            currentWeapon.Initialize();
        }
      

    
    }

    public void SelectRocketWeapon()
    {
        if (currentWeapon == null )
        {
            playerWeaponHolder.gameObject.AddComponent<RocketWeapon>();
            currentWeapon = playerWeaponHolder.gameObject.GetComponent<RocketWeapon>();
            currentWeapon.weaponData = weaponDatas[2];
            currentWeapon.Initialize();
        }
        else if (currentWeapon.weaponData != weaponDatas[2])
        {
            Destroy(currentWeapon);
            playerWeaponHolder.gameObject.AddComponent<RocketWeapon>();
            currentWeapon = playerWeaponHolder.gameObject.GetComponent<RocketWeapon>();
            currentWeapon.weaponData = weaponDatas[2];
            currentWeapon.Initialize();
        }
    }

    public void SelectShotgunWeapon()
    {


        if(currentWeapon == null)
        {
            playerWeaponHolder.gameObject.AddComponent<ShotgunWeapon>();
            currentWeapon = (ShotgunWeapon)playerWeaponHolder.gameObject.GetComponent<ShotgunWeapon>();
            currentWeapon.weaponData = weaponDatas[3];
            currentWeapon.Initialize();
        }
        else if(currentWeapon.weaponData != weaponDatas[3])
        {
            Destroy(currentWeapon);
            playerWeaponHolder.gameObject.AddComponent<ShotgunWeapon>();
            currentWeapon = (ShotgunWeapon)playerWeaponHolder.gameObject.GetComponent<ShotgunWeapon>();
            currentWeapon.weaponData = weaponDatas[3];
            currentWeapon.Initialize();
        }

       
    }


}
