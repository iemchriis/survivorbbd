using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{

    [Header("Weapon Stats")]
    [SerializeField] private int weaponDamage;
    [SerializeField] private string weaponType;
    [SerializeField] private float weaponROF;
    [Space]
    [Header("Projectile Stats")]
    [SerializeField] private GameObject[] bulletTypes;
    [SerializeField] private GameObject bulletProjectile;
    [SerializeField] private float projectileSpeed;


    public void SetWeaponStats(int _weaponDamage, string _weaponType)
    {
        weaponDamage = _weaponDamage;
        weaponType = _weaponType;
        
    }

    public int GetWeaponDamage()
    {
        return weaponDamage;
    }

    public float GetWeaponROF()
    {
        return weaponROF;
    }

    public GameObject GetProjectile()
    {
        return bulletProjectile;
    }

    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }
}
