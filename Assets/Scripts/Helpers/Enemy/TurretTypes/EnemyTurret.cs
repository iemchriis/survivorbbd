using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used for Stun, Slow and Missile Turrets
/// </summary>
public class EnemyTurret : MonoBehaviour
{


    //[SerializeField] private float attackRange;
    public string TargetName;
    public bool isHackable;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform target;
    [SerializeField] protected Transform firePoint;
   
    [Space]
    [SerializeField] protected float fireRate;
    [SerializeField] private float projectileVelocity;
    protected float fireTime;

    protected virtual void Start()
    {
        TargetName = "Player";
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


    protected virtual void FireTurret()
    {
        fireTime -= Time.deltaTime;
        if(fireTime <= 0)
        {
            LaunchProjectile();
            fireTime = fireRate;
        }
    }

    protected virtual void LaunchProjectile()
    {
        GameObject go = Instantiate(projectile, firePoint.position, Quaternion.identity);

        var rb = go.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * projectileVelocity, ForceMode.Impulse);

    }

    
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TargetName))
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
