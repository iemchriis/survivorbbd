using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : BaseWeapon
{
    
    private float gunRange = 100f;
    private float laserDuration = 0.1f;
    public LaserData laserData;
    private LineRenderer laserLine;

  

   

    public override void Initialize()
    {
        
        laserLine = GetComponent<LineRenderer>();
        laserData = (LaserData)weaponData;
        
        base.Initialize();

    }

   
    void Update()
    {
        CanFire(weaponData.GetCurrentFireRate());
    }

    public override void Shoot()
    {
        AudioManager.Instance.PlaySFX("Laser");
        laserLine.SetPosition(0, firePos.position);

        RaycastHit hit;
        if (Physics.Raycast(firePos.position, firePos.forward, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            
            if(hit.transform.CompareTag("Enemy"))
            {
               
                var enemy = hit.transform.GetComponent<EnemyScript>();
                enemy.TakeDamage(laserData.GetCurrentDamage());
                enemy.TakeDamageOverTime(laserData.GetBurnDamage(), laserData.GetBurnDuration(), 1);
            }

            
        }
        else
        {
            laserLine.SetPosition(1, firePos.position * gunRange);
        }
        StartCoroutine(ShootLaser());
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
