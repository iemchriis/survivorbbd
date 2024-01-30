using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : BaseProjectile
{
    private float bulletDropOff;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        
    }


    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

}
