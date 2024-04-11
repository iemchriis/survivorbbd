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
        if (m_Movement.rotJoystick.Vertical == 0 || m_Movement.rotJoystick.Horizontal == 0)
            return;

        CanFire(ballisticData.GetCurrentFireRate());
    }

    private bool CheckCrit()
    {
        var rand = Random.value;
        //Debug.Log(rand);
        if (rand < PlayerDataManager.Instance.GetCritChanceValue() + ballisticData.GetCurrentCritRate())
        {
            // Critical hit
           
            Debug.Log("Crit");
            totalDamage  = ballisticData.GetCritDamage();
            return true;
        }
        else
        {
            // Normal hit
            totalDamage = ballisticData.GetCurrentDamage();
            return false;
        }
    }

    public override void Shoot()
    {
        
        var crit = CheckCrit();
        GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        var bullet = bulletObj.GetComponent<PiercingBallistic>();

      
        bullet.SetProjectileStats(totalDamage, ballisticData.projectileSpeed, crit);
        bullet.SetPierceLevel(ballisticData.GetPierceCount());
        bullet.ShootProjectile(transform.forward);

    }
}
