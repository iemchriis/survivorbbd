using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rocket", menuName = "Weapons/Rocket")]
public class RocketData : WeaponDatas
{
    [Header("Rocket Properties")]
    public float[] splashRadius;
    public int[] splashDamage;

}
