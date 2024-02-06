using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : BaseWeapon
{
    public RocketData rocketData;
    int totalDamage;

    public override void Initialize()
    {

        rocketData = (RocketData)weaponData;
        base.Initialize();

    }

    private void Update()
    {
        CanFire(weaponData.fireRate[weaponData.weaponLevel -1]);
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
            //totalDamage = damage;
        }
    }



    public override void Shoot()
    {

        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<RocketProjectile>();


        bullet.SetProjectileStats(totalDamage, weaponData.projectileSpeed);
        //bullet.SetDamageValues(r)
        bullet.ShootProjectile(transform.forward);

    }
}
