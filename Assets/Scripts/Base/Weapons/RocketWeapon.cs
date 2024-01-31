using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : BaseWeapon
{
    [SerializeField]private GameObject bulletPrefab;


    public override void Initialize()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();
        projectileSpeed = 10f;


        base.Initialize();

        rateOfFire = 1f;


    }

    private void Update()
    {
        CanFire();
    }


    public override void Shoot()
    {
        if(bulletPrefab == null)
        {
            bulletPrefab = holder.GetProjectile();
            return;
        }


        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<BaseProjectile>();

        bullet.SetProjectileStats(damage, projectileSpeed);
        bullet.ShootProjectTile(transform.forward);
    }
}
