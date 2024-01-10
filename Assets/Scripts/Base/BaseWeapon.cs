using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    public Transform firePos;
    public float rateOfFire;

    private float fireTime = 0;

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

    void Shoot()
    {
        GameObject bullet  = Instantiate(bulletPrefab, firePos.position,firePos.rotation);
        bullet.GetComponent<BaseProjectile>().ShootProjectTile(transform.forward);
    }

}
