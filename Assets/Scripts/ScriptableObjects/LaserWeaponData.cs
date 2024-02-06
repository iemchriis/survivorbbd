using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Laser", menuName = "Weapons/Laser")]
public class LaserData : WeaponDatas
{
    [Header("Laser Properties")]
    public float laserRange;
    public int[] burnDamage;
    public float[] burnDuration;
    public float[] burnTicks;


    public int GetBurnDamage()
    {
        return burnDamage[weaponLevel - 1];

    }
    public float GetBurnDuration()
    {
        return burnDuration[weaponLevel - 1];

    }
}
