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
        var rand = Random.value;
        //Debug.Log(rand);
        if (rand < PlayerDataManager.Instance.GetCritChanceValue() + ballisticData.GetCurrentCritRate())
        {
            // Critical hit
           
            Debug.Log("Crit");
            totalDamage  = ballisticData.GetCritDamage();
        }
        else
        {
            // Normal hit
            totalDamage = ballisticData.GetCurrentDamage();
        }
    }

    public override void Shoot()
    {
        CheckCrit();

        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<PiercingBallistic>();      

        bullet.SetProjectileStats(totalDamage, ballisticData.projectileSpeed);
        bullet.SetPierceLevel(ballisticData.GetPierceCount());
        bullet.ShootProjectile(transform.forward);

    }
}
