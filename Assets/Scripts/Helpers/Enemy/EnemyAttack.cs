using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField]protected float AttackRange;


    protected EnemyMovement movement;
    protected bool isAttacking;

    protected virtual void Start()
    {
        movement = GetComponent<EnemyMovement>();
        movement.Navmesh.stoppingDistance = AttackRange;
    }

    protected virtual void CheckRange()
    {
        
    }

    public virtual void ReturnToFollow()
    {
        movement.Navmesh.isStopped = false;
    }

    public virtual void Attack()
    {
        movement.Navmesh.isStopped = true;
    }
}
