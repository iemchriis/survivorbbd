using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWeapon : BaseWeapon
{
    private WeaponHolder holder;
    private int damage;
    private float rateOfFire;
    private float projectileSpeed;


    void Start()
    {
        firePos = this.transform;
       

       
        projectileSpeed = 20f;

        damage = PlayerDataManager.Instance.GetDroneDamage();
        rateOfFire = (float)PlayerDataManager.Instance.GetDroneROFValue();
        

        damage = 10;
        rateOfFire = 0.5f;

       fireTime = rateOfFire;

    }

    private void Update()
    {
        CanFire(rateOfFire);
    }

    public override void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<BaseProjectile>();

        bullet.SetProjectileStats(damage,projectileSpeed);
        bullet.ShootProjectile(transform.forward);
    }


    public void UpgradeDroneROF()
    {
        rateOfFire -= 0.1f;
    }
}
