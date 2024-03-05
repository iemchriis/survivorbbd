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
        attackCollider.enabled = false;
    }

    public void EnableAttackCollider(bool enable)
    {
        attackCollider.enabled = enable;
    }

}
