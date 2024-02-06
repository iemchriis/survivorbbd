using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDatas : ScriptableObject
{
   
    public GameObject projectile;
    public float projectileSpeed;
    [Space]
    public int weaponLevel;
    [Space]
    public int[] damage;
    private int critDamage;
    public float[] critMultiplier;
    [Space]
    public float[] fireRate;
    private float fireTime = 0f;



    public int GetCurrentDamage()
    {
        return damage[weaponLevel - 1];
    }

    public float GetCurrentFireRate()
    {
        return fireRate[weaponLevel - 1];
    }

    public float GetCurrentCritDamage()
    {
        return critMultiplier[weaponLevel - 1];
    }

}







