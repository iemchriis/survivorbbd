using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeModel : MonoBehaviour
{
    public WeaponDatas[] weaponDatas;

    public int weaponIndex;
    public int[] upgradeCosts;

   

   

    public Sprite GetWeaponSprite()
    {
        return weaponDatas[weaponIndex].weaponSprite;
    }

    public string GetWeaponName()
    {
        return weaponDatas[weaponIndex].weaponName;
    }

    public int GetNextDamage()
    {
        int lvl = weaponDatas[weaponIndex].weaponLevel;

        return weaponDatas[weaponIndex].damage[lvl];
    }

    public float GetNextROF()
    {
        int lvl = weaponDatas[weaponIndex].weaponLevel;

        return weaponDatas[weaponIndex].fireRate[lvl];
    }

    public float GetNextRange()
    {
        int lvl = weaponDatas[weaponIndex].weaponLevel;

        return weaponDatas[weaponIndex].damageRange[lvl];
    }

    public float GetNextCritChance()
    {
        int lvl = weaponDatas[weaponIndex].weaponLevel;

        return weaponDatas[weaponIndex].critChance[lvl];
    }

    public string GetSpecialEffect()
    {
        return weaponDatas[weaponIndex].weaponEffect;
    }

    public int GetSpecialStat(int curIndex)
    {
        switch (curIndex)
        {
            case 0:
                {
                    BallisticData data = (BallisticData)weaponDatas[curIndex];
                    return data.GetPierceCount();
                }

            case 1:
                {
                    LaserData data = (LaserData)weaponDatas[curIndex];
                    return data.GetBurnDamage();
                }
        
            case 2:
                {
                    RocketData data = (RocketData)weaponDatas[curIndex];
                    return data.GetSplashDamage();
                }

            case 3:
                {
                    ShotgunData data = (ShotgunData)weaponDatas[curIndex];
                    return data.GetPelletCount();
                }
        }
        return 0;
    }

    public int GetNextSpecialStat(int curIndex)
    {
        switch (curIndex)
        {
            case 0:
                {
                    BallisticData data = (BallisticData)weaponDatas[curIndex];
                    int lvl = data.weaponLevel;
                    return data.pierceCount[lvl];
                }

            case 1:
                {
                    LaserData data = (LaserData)weaponDatas[curIndex];
                    int lvl = data.weaponLevel;
                    return data.burnDamage[lvl];
                }

            case 2:
                {
                    RocketData data = (RocketData)weaponDatas[curIndex];
                    int lvl = data.weaponLevel;
                    return data.splashDamage[lvl];
                }

            case 3:
                {
                    ShotgunData data = (ShotgunData)weaponDatas[curIndex];
                    int lvl = data.weaponLevel;
                    return data.pelletCount[lvl];
                }
        }
        return 0;
    }

}
