using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosionAOE : MonoBehaviour
{
    private SphereCollider aoe;

    [SerializeField] private int damage;


    private void Awake()
    {
        aoe = GetComponent<SphereCollider>();
    }

    public void SetValues(int damage, float radius)
    {
        this.damage = damage;
        aoe.radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
