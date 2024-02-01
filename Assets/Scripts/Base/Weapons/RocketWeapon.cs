using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : BaseWeapon
{
    [SerializeField]private GameObject bulletPrefab;
    int totalDamage;

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

    void CheckCrit()
    {
        if (Random.value < PlayerDataManager.Instance.GetCritChanceValue())
        {
            // Critical hit
            totalDamage *= 2;
        }
        else
        {
            // Normal hit
            totalDamage = damage;
        }
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

        bullet.SetProjectileStats(totalDamage, projectileSpeed);
        bullet.ShootProjectile(transform.forward);

    }
}
