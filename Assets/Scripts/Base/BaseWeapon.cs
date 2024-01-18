using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;

    public Transform firePos;
    public float rateOfFire;
    public float fireTime = 0;

    public bool canFire;

    private void Start()
    {
        fireTime = rateOfFire;
    }

    private void Update()
    {
        if(canFire)
        {
            fireTime -= Time.deltaTime;
            if(fireTime <= 0)
            {
                Shoot();
                fireTime = rateOfFire;
                
            }
        }
    }

    public virtual void Shoot()
    {
        GameObject bullet  = Instantiate(bulletPrefab, firePos.position,firePos.rotation);
        bullet.GetComponent<BaseProjectile>().SetDamage(GetComponent<WeaponHolder>().GetWeaponDamage());
        bullet.GetComponent<BaseProjectile>().ShootProjectTile(transform.forward);
    }

}
