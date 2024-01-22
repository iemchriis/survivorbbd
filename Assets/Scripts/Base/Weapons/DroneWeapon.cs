using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWeapon : BaseWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    void OnEnable()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();

        damage = holder.GetWeaponDamage();
        rateOfFire = holder.GetWeaponROF();
        fireTime = rateOfFire;

       

    }

    private void Update()
    {
        CanFire();
    }

    public override void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<BaseProjectile>();

        bullet.SetDamage(damage);
        bullet.ShootProjectTile(transform.forward);
    }
}
