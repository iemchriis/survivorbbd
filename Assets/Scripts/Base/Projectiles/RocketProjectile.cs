using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : BaseProjectile
{
    [SerializeField] private GameObject aoeEffect;

    [SerializeField] private float explosionRadius;


    private void Start()
    {
        damage = 20;
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            rb.velocity = Vector3.zero;
            aoeEffect.SetActive(true);
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            Debug.Log("Direct Hit" + damage);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
