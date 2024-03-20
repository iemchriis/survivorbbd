using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosionAOE : MonoBehaviour
{
    [SerializeField]private SphereCollider aoe;

    private int damage;

    private void Awake()
    {
        Destroy(gameObject, 1f);
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
                Destroy(this.gameObject);
            }
        }
    }
}
