using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : BaseWeapon
{
    private GameObject bulletPrefab;

    [SerializeField] private int shotgunPellets;

    [SerializeField] private Vector3[] shotSpread;

    public float ConeSize;

    float xSpread = Random.Range(-1, 1);
    float ySpread = Random.Range(-1, 1);

    void OnEnable()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();
        projectileSpeed = holder.GetProjectileSpeed();

        damage = holder.GetWeaponDamage();
        rateOfFire = holder.GetWeaponROF();
        fireTime = rateOfFire;

        GameManager.Instance.targeting.weapon = this;

    }


    //normalize the spread vector to keep it conical
    //Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * ConeSize;
    //Quaternion rotation = Quaternion.Euler(spread) * bulletSpawn.rotation;
    //var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, rotation);

    void GenerateSpread()
    {
        shotSpread[0] = transform.forward;
        shotSpread[1] = transform.right + new Vector3(0, 0, -3f);


        
    }

    private void Update()
    {
        CanFire();
    }

    public override void Shoot()
    {
        List<ShotgunProjectile> projectiles = new List<ShotgunProjectile>();

        for (int i = 0; i < shotgunPellets; i++)
        {
            GameObject bulletObj = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            var bullet = bulletObj.GetComponent<ShotgunProjectile>();

            projectiles.Add(bullet);
        }

        projectiles[0].ShootProjectTile(transform.forward);

       

        
    }
}
