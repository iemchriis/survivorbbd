using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowProjectile : BaseProjectile
{
    [SerializeField] private float slowDuration;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySFX("Laser");
            Debug.Log("Enemy Hit");
            var enemy = other.GetComponent<EnemyScript>();

            enemy.TakeDamage(damage);
            //enemy.ApplyEffect()
            

            Destroy(gameObject);
        }
    }

}
