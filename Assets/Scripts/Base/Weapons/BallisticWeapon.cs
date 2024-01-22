using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticWeapon : BaseWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    void OnEnable()
    {
        firePos = this.transform;
        holder = GetComponent<WeaponHolder>();

        bulletPrefab = holder.GetProjectile();

        damage = holder.GetWeaponDamage();
        rateOfFire = holder.GetWeaponROF();
        fireTime = rateOfFire;

        GameManager.Instance.targeting.weapon = this;

    }

    private void Update()
    {
        CanFire();
    }

    public override void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        bullet.GetComponent<BaseProjectile>().SetDamage(damage);
        bullet.GetComponent<BaseProjectile>().ShootProjectTile(transform.forward);
    }
}
