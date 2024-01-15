using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : MonoBehaviour
{
    private Rigidbody rb;
    private int canPierce;
    private int pierceCount;

    [SerializeField] private float projectileVelocity;

    private int damage;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        projectileVelocity = 30f;

        Destroy(gameObject, 10f);

        //damage = GetComponent<WeaponHolder>().GetWeaponDamage();
    }


    public void SetDamage(int dmg)
    {
        damage = dmg;
    }

    public void ShootProjectTile(Vector3 direction)
    {   
        rb.AddForce(direction * projectileVelocity, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
