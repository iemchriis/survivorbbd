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
        bulletPrefab = rocketData.projectile;
       
        base.Initialize();

    }

    private void Update()
    {
        CanFire(rocketData.GetCurrentFireRate());
    }

    void CheckCrit()
    {
        var rand = Random.value;
        //Debug.Log(rand);
        if (rand < PlayerDataManager.Instance.GetCritChanceValue() + rocketData.GetCurrentCritRate())
        {
            // Critical hit

            Debug.Log("Crit");
            totalDamage = rocketData.GetCritDamage();
        }
        else
        {
            // Normal hit
            totalDamage = rocketData.GetCurrentDamage();
        }
    }



    public override void Shoot()
    {
        CheckCrit();

        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<RocketProjectile>();


        bullet.SetProjectileStats(totalDamage, rocketData.projectileSpeed);
        bullet.SetSplashDamageValues(rocketData.GetSplashDamage(), rocketData.GetSplashRadius());
        bullet.ShootProjectile(transform.forward);

    }
}
