using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ballistic", menuName = "Weapons/Ballistic")]
public class BallisticData : WeaponDatas
{
    [Header("Piercing Properties")]
    public bool canPierce;
    public int[] pierceCount;



    public int GetPierceCount()
    {
        return pierceCount[weaponLevel - 1];
    }
}
