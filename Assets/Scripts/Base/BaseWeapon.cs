using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public WeaponHolder holder;
    [SerializeField] protected GameObject bulletPrefab;

    public Transform firePos;
    public int damage;
    public float rateOfFire;
    public float fireTime = 0;

    public bool canFire;

    

    
    void OnEnable()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();

        damage = holder.GetWeaponDamage();
        rateOfFire = holder.GetWeaponROF();
        fireTime = rateOfFire;

        FindObjectOfType<PlayerVision>().weapon = this;
        
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
        bullet.GetComponent<BaseProjectile>().SetDamage(damage);
        bullet.GetComponent<BaseProjectile>().ShootProjectTile(transform.forward);
    }

}
