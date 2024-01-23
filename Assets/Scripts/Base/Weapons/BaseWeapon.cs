using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public WeaponHolder holder;
    
    public Transform firePos;
    public int damage;
    public float rateOfFire;
    public float projectileSpeed;
    [SerializeField]protected float fireTime = 0;

    public bool canFire;

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
