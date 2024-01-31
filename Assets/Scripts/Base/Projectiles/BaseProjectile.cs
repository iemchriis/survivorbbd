using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : MonoBehaviour
{
    protected Rigidbody rb;

    [SerializeField] protected float projectileVelocity;

    protected int damage;
    


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 10f);      
    }

 

    public virtual void SetProjectileStats(int dmg, float projVelocity)
    {
        damage = dmg;
        projectileVelocity = projVelocity;
    }

    public virtual void ShootProjectTile(Vector3 direction)
    {   
        rb.AddForce(direction * projectileVelocity, ForceMode.Impulse);
    }


    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
