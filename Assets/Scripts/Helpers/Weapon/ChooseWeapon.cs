using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    private WeaponUpgradePresenter weaponUpgrade;
    public int weaponIndex;

    private void Start()
    {
        weaponUpgrade = FindAnyObjectByType<WeaponUpgradePresenter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (weaponUpgrade != null)
        {
            weaponUpgrade.SetActiveWeapon(weaponIndex);
        }    
    }
}
