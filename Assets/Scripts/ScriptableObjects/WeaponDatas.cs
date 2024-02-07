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
    public float[] damageRange;
    private int critDamage;
    public float[] critChance;
    public float[] critMultiplier;
    [Space]
    public float[] fireRate;
   



    public int GetCurrentDamage()
    {
        return damage[weaponLevel - 1];
    }

    public int GetCritDamage()
    {
        critDamage = (int) (damage[weaponLevel - 1] * critMultiplier[weaponLevel -1]);
        return critDamage;
    }

    public float GetCurrentFireRate()
    {
        return fireRate[weaponLevel - 1];
    }

    public float GetCurrentCritDamage()
    {
        return critMultiplier[weaponLevel - 1];
    }

    public float GetDamageRange()
    {
        return damageRange[weaponLevel - 1];
    }
}







