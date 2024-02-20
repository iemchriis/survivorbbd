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

    private bool CheckCrit()
    {
        var rand = Random.value;
        
        if (rand < PlayerDataManager.Instance.GetCritChanceValue() + rocketData.GetCurrentCritRate())
        {
            // Critical hit
            Debug.Log("Crit");
            totalDamage = rocketData.GetCritDamage();
            return true;
        }
        else
        {
            // Normal hit
            totalDamage = rocketData.GetCurrentDamage();
            return false;
        }
    }


    public override void Shoot()
    {
        CheckCrit();

        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<RocketProjectile>();


        bullet.SetProjectileStats(totalDamage, rocketData.projectileSpeed, CheckCrit());
        bullet.SetSplashDamageValues(rocketData.GetSplashDamage(), rocketData.GetSplashRadius());
        bullet.ShootProjectile(transform.forward);

    }
}
