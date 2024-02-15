using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponDatas : ScriptableObject
{
    [Header("UI Paramaters")]
    public string weaponName;
    public string weaponEffect;
    public Sprite weaponSprite;
    [Space]
    [Header("Weapon Statistics")]
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
    public float[] fireRate;
    
   

    public void IncreaseWeaponLevel()
    {
        weaponLevel++;
    }

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

    public float GetCurrentCritRate()
    {
        return critChance[weaponLevel - 1];
    }

   

    public float GetDamageRange()
    {
        return damageRange[weaponLevel - 1];
    }
}







