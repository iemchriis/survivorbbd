using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Laser", menuName = "Weapons/Laser")]
public class LaserData : WeaponDatas
{
    [Header("Laser Properties")]
    public float[] laserRange;
    public float[] burnDamage;
    public float[] burnDuration;
    public float[] burnTicks;
}
