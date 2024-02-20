using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : BaseWeapon
{
    
    [SerializeField] private int shotgunPellets;
    public ShotgunData shotgunData;

    private int totalDamage;
 

    public override void Initialize()
    {
        shotgunData = (ShotgunData)weaponData;
        bulletPrefab = shotgunData.projectile;

        shotgunPellets = shotgunData.pelletCount[shotgunData.weaponLevel -1];
        base.Initialize();

        

    }


    //normalize the spread vector to keep it conical
    //Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * ConeSize;
    //Quaternion rotation = Quaternion.Euler(spread) * bulletSpawn.rotation;
    //var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, rotation);
    //float angle = spreadAngle * (i - (shotgunPellets - 1) / 2) / (shotgunPellets - 1);
    //Quaternion rotation = Quaternion.AngleAxis(angle, firePos.forward) * firePos.rotation;
    //Debug.Log(rotation);
    //float pelletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
    //float pelletDirZ = transform.position.z + Mathf.Cos((angle * Mathf.PI / 180f));

    //Vector3 pelletVector = new Vector3(pelletDirX, 0, pelletDirZ);
    //Vector3 pelletDirection = (pelletVector - transform.position).normalized;

    //float offset = (i - (shotgunPellets / 2)) * spreadAngle;
    //newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + offset);

    private void Update()
    {
        CanFire(weaponData.fireRate[weaponData.weaponLevel-1]);
    }

    private bool CheckCrit()
    {
        var rand = Random.value;
        //Debug.Log(rand);
        if (rand < PlayerDataManager.Instance.GetCritChanceValue() + shotgunData.GetCurrentCritRate())
        {
            // Critical hit

            Debug.Log("Crit");
            totalDamage = shotgunData.GetCritDamage();
            return true;
        }
        else
        {
            // Normal hit
            totalDamage = shotgunData.GetCurrentDamage();
            return false;
        }
    }

    public override void Shoot()
    {

        Quaternion newRot;

        for (int i = 0; i < shotgunPellets; i++)
        {
            float angle = shotgunData.spreadAngle[shotgunData.weaponLevel -1] * (i - (shotgunPellets - 1) / 2) / (shotgunPellets -1);

            newRot = Quaternion.AngleAxis(angle, firePos.up) * firePos.rotation;
            
            GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            bulletObj.transform.rotation = newRot;

            var bullet = bulletObj.GetComponent<ShotgunProjectile>();
            bullet.SetProjectileStats(totalDamage, shotgunData.projectileSpeed, CheckCrit());
            bullet.ShootProjectile(bullet.transform.forward);
            
        }
        
    }
}
