using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public WeaponHolder holder;
    
    public Transform firePos;
    public int damage;
    public float rateOfFire;
    public float projectileSpeed;
    [SerializeField]protected float fireTime = 0;

    public bool canFire;


    public virtual void Initialize()
    {

        damage = holder.GetWeaponDamage();
        rateOfFire = holder.GetWeaponROF();
        fireTime = rateOfFire;

        GameManager.Instance.targeting.weapon = this;
    }


    public virtual void CanFire()
    {
        if (canFire)
        {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0)
            {
                Shoot();
                fireTime = rateOfFire;

            }
        }
    }

    public virtual void Shoot()
    {
       
    }

}
