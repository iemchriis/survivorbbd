using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWeapon : BaseWeapon
{
    private WeaponHolder holder;
    private int damage;
    private float rateOfFire;
    private float projectileSpeed;


    void OnEnable()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();

        damage = PlayerDataManager.Instance.GetDroneDamage();
        rateOfFire = (float)PlayerDataManager.Instance.GetDroneROFValue();
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
}
