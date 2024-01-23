using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : BaseProjectile
{
    private int damageOverTime;
    private int ticks;
    private float duration;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            var enemy = other.GetComponent<EnemyScript>();

            enemy.TakeDamage(damage);
            enemy.TakeDamageOverTime(damage, duration, ticks);
            
            Destroy(gameObject);
        }
    }
}
