using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : MonoBehaviour
{
    protected Rigidbody rb;

    [SerializeField]protected float projectileVelocity;
    protected string shooter; 
    [SerializeField]protected int damage;
    protected bool isCrit;
    


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 5f);      
    }

 

    public virtual void SetProjectileStats(int damage, float projectileVelocity, bool isCrit = false, string shooter = "Player")
    {
        this.damage = damage;
        this.projectileVelocity = projectileVelocity;
        this.isCrit = isCrit;
        this.shooter = shooter;
    }

    public virtual void ShootProjectile(Vector3 direction)
    {   
        rb.AddForce(direction * projectileVelocity, ForceMode.Impulse);
    }


    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (shooter == "Enemy")
                return;

            
            other.GetComponent<IDamagable>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            if (shooter == "Player")
                return;

            other.GetComponent<IDamagable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public CharacterBase.DamageType CheckIfCrit()
    {
        if(isCrit)
        {
            return CharacterBase.DamageType.CRIT;
        }
        else
        {
            return CharacterBase.DamageType.NORMAL;
        }
    }
}
