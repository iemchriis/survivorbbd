using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowProjectile : BaseProjectile
{
    [SerializeField]private int slowAmount;
    [SerializeField]private float slowDuration;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySFX("Laser");
            Debug.Log("Enemy Hit");

            var enemyHealth = other.GetComponent<IDamagable>();
            var enemyMovement = other.GetComponent<ISlowed>();

            enemyHealth.TakeDamage(damage);
            enemyMovement.ApplySlowEffect(slowAmount, slowDuration);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            var slow = other.GetComponent<ISlowed>();
            
            if(slow != null)
            {
                slow.ApplySlowEffect(slowAmount,slowDuration);    
            }

            var dmg = other.GetComponent<IDamagable>();

            if(dmg != null)
            {
                dmg.TakeDamage(damage);
            }
        }
    }

}
