using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    //[SerializeField] private float attackRange;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
   
    [Space]
    [SerializeField] private float fireRate;
    [SerializeField] private float projectileVelocity;
    private float fireTime;

    private void Start()
    {
        fireTime = fireRate;
        GameManager.Instance.enemyCount++;
    }


    private void Update()
    {
        if (target == null)
            return;

        transform.LookAt(target);

        FireTurret();
    }


    void FireTurret()
    {
        fireTime -= Time.deltaTime;
        if(fireTime <= 0)
        {
            LaunchProjectile();
            fireTime = fireRate;
        }
    }

    void LaunchProjectile()
    {
        GameObject go = Instantiate(projectile, firePoint.position, Quaternion.identity);

        var rb = go.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * projectileVelocity, ForceMode.Impulse);

    }

    
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }
}
