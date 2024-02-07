using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    private WeaponUpgrade weaponUpgrade;
    public int weaponIndex;

    private void Start()
    {
        weaponUpgrade = FindAnyObjectByType<WeaponUpgrade>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (weaponUpgrade != null)
        {
            weaponUpgrade.SetActiveWeapon(weaponIndex);
        }    
    }
}
