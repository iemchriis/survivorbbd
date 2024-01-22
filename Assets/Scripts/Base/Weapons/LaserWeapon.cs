using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : BaseWeapon
{
    
    private float gunRange = 100f;
    public float laserDuration = 0.1f;

    private LineRenderer laserLine;

    
    private float burnDuration = 10f;
    private int burnTick = 2;

   

    void OnEnable()
    {
        holder = GetComponent<WeaponHolder>();
        laserLine = GetComponent<LineRenderer>();

        firePos = this.transform;

        rateOfFire =holder.GetWeaponROF();
        fireTime = rateOfFire;
        damage = holder.GetWeaponDamage();

        GameManager.Instance.targeting.weapon = this;
    }

   
    void Update()
    {
        if(canFire)
        {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0)
            {
                fireTime = rateOfFire;
                Shoot();
            }
        }

       
    }

    public override void Shoot()
    {
        
        laserLine.SetPosition(0, firePos.position);

        RaycastHit hit;
        if (Physics.Raycast(firePos.position, firePos.forward, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            
            if(hit.transform.CompareTag("Enemy"))
            {
                Debug.Log(hit.transform.name);
                var enemy = hit.transform.GetComponent<EnemyScript>();
                enemy.TakeDamage(damage);
                enemy.TakeDamageOverTime(damage, 10f, 2);
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
