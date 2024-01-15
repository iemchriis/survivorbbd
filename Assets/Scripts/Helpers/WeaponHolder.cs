using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private string weaponType;



    public void SetWeaponStats(int _weaponDamage, string _weaponType)
    {
        weaponDamage = _weaponDamage;
        weaponType = _weaponType;
    }

    public int GetWeaponDamage()
    {
        return weaponDamage;
    }
}
