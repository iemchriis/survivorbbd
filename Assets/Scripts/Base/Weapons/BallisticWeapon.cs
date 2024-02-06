using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticWeapon : BaseWeapon
{
    private int totalDamage;
    public BallisticData ballisticData;
    public override void Initialize()
    {            
        ballisticData = (BallisticData)weaponData;
        bulletPrefab = ballisticData.projectile;
        base.Initialize();

    }

    private void Update()
    {
        CanFire(ballisticData.GetCurrentFireRate());
    }

    void CheckCrit()
    {
        if (Random.value < PlayerDataManager.Instance.GetCritChanceValue())
        {
            // Critical hit
            totalDamage  = (int)(ballisticData.GetCurrentDamage() * ballisticData.critMultiplier[weaponData.weaponLevel -1]);
        }
        else
        {
            // Normal hit
            totalDamage = ballisticData.GetCurrentDamage();
        }
    }

    public override void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<BaseProjectile>();      

        bullet.SetProjectileStats(totalDamage, ballisticData.projectileSpeed);
        bullet.ShootProjectile(transform.forward);

    }
}
