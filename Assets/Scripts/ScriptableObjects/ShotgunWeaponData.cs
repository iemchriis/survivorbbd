using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Weapons/Shotgun")]
public class ShotgunData : WeaponDatas
{
    [Header("Shotgun Properties")]
    public float[] rangeDropOff;
    public int[] pelletCount;
    public float[] spreadAngle;
    public int spreadRandom;
}