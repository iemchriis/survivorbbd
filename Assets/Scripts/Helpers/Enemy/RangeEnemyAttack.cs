using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAttack : EnemyAttack
{
    [SerializeField]private GameObject projectile;
    [SerializeField]private Transform firePoint;

    [SerializeField]private float projectileVelocity;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (movement.Target != null)
            CheckRange();
    }

    protected override void CheckRange()
    {
        var target = movement.Target;
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= AttackRange)
        {
            Attack();
        }
        else
        {
            ReturnToFollow();
        }
    }

    public override void Attack()
    {
        base.Attack();
        movement.Health.Animator.SetBool("Attack", true);
    }

    public override void ReturnToFollow()
    {
        base.ReturnToFollow();
        
    }

    void LaunchProjectile()
    {
        GameObject go = Instantiate(projectile, firePoint.position, Quaternion.identity);

        var rb = go.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * projectileVelocity, ForceMode.Impulse);

    }


}
