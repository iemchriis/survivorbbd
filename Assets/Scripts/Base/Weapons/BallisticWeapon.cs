using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticWeapon : BaseWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    public override void Initialize()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();
       


        base.Initialize();
        projectileSpeed = 20f;

    }

    private void Update()
    {
        CanFire();
    }

    public override void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<BaseProjectile>();

        bullet.SetProjectileStats(damage,projectileSpeed);
        bullet.ShootProjectTile(transform.forward);
    }
}
