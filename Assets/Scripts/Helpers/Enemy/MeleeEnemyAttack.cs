using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : EnemyAttack
{
    [SerializeField] private Collider attackCollider;
    protected override void Start()
    {
        base.Start();

    }

    private void Update()
    {
        if(movement.Target != null)
            CheckRange();
    }

    private void EnableAttackCollider()
    {
        attackCollider.enabled = true;
    }

    private void DisablettackCollider()
    {
        attackCollider.enabled = false;
    }

    protected override void CheckRange()
    {
        var target = movement.Target;
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= AttackRange)
        {
            if(!isAttacking)
            {
                isAttacking = true;
                Attack();
            }
            
        }
        else
        {
            if(isAttacking)
            {
                isAttacking = false;
                ReturnToFollow();
            }
           
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
        attackCollider.enabled = false;
    }

   

}
