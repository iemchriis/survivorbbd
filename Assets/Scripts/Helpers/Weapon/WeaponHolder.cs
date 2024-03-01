using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{

   // [Header("Weapon Stats")]
    private int weaponDamage;
    private string weaponType;
    private float weaponROF;
    //[Space]
    //[Header("Projectile Stats")]
    public GameObject bulletProjectile;
    private float projectileSpeed;

    [SerializeField] private PlayerVision vision;

    private void Update()
    {
        if(vision != null)
            SetAngleToEnemy();
    }

    void SetAngleToEnemy()
    {
        if(vision.nearestEnemy == null)
            return;

        transform.LookAt(vision.nearestEnemy.transform);
    }
    public void SetWeaponStats(int _weaponDamage, string _weaponType)
    {
        weaponDamage = _weaponDamage;
        weaponType = _weaponType;
        
    }

    public void SetProjectile(GameObject bullet)
    {
        bulletProjectile = bullet;
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


    public void UpgradeWeaponROF()
    {
        weaponROF -= 0.1f;
    }
}
