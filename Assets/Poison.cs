using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public bool canFire;
    private float fireTime;
    public float rateOfFire;
    private int damage;


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                fireTime -= Time.deltaTime;
                if (fireTime <= 0)
                {
                    fireTime = rateOfFire;
                    enemy.TakeDamage(damage);
                }
            }
        }
     
    }
}
