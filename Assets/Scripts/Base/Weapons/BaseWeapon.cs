using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    //public WeaponHolder holder;
    [SerializeField]protected GameObject bulletPrefab;
    [SerializeField]protected Transform firePos;
    [HideInInspector]public WeaponDatas weaponData;
 
    [SerializeField]protected float fireTime = 0;

    public bool canFire;

    

    public virtual void Initialize()
    {
        firePos = this.transform;
        GameManager.Instance.targeting.weapon = this;
    }


    public virtual void CanFire(float rateOfFire)
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
