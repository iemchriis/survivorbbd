using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used for Stun, Slow and Missile Turrets
/// </summary>
public class EnemyTurret : MonoBehaviour
{

    public string TargetName;
    public bool isHackable;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform target;
    [SerializeField] protected Transform firePoint;
   
    [SerializeField] protected GameObject turretTemp;
    [SerializeField] protected Material allyMaterial;
   
    [Space]
    [SerializeField] protected float fireRate;
    [SerializeField] private float projectileVelocity;
    protected float fireTime;

    protected virtual void Start()
    {
        TargetName = "Player";
        fireTime = fireRate;
        Debug.Log("Added to Level");
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

        var proj = go.GetComponent<BaseProjectile>();

        proj.SetProjectileStats(10, 20f,false, transform.parent.tag);

        proj.ShootProjectile(firePoint.forward);
        //rb.AddForce(firePoint.forward * projectileVelocity, ForceMode.Impulse);

    }

    public void ChangeTarget()
    {
        if (!isHackable)
            return;

        Debug.Log("Turrets Hacked");
        target = null;
        TargetName = "Enemy";
        this.transform.parent.tag = "Friendly";
        turretTemp.GetComponent<Renderer>().material = allyMaterial;
    }

    
    

    protected void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TargetName))
        {
            target = other.transform;
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(TargetName))
        {
            target = other.transform;

            if(other.GetComponent<CharacterBase>().IsDead())
            {
                target = null;
            }
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TargetName))
        {
            target = null;
        }
    }
}
