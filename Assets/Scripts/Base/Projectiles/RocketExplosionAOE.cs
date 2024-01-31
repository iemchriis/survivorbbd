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
        damage = 5;
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
                Debug.Log("Explosion Damage");
                enemy.TakeDamage(damage);
            }
        }
    }
}
