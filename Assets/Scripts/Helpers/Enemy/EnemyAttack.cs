using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField]protected float AttackRange;


    protected EnemyMovement movement;


    protected virtual void Start()
    {
        movement = GetComponent<EnemyMovement>();
        
    }

    protected virtual void CheckRange()
    {
        var target = movement.Target;
        float dist = Vector3.Distance(transform.position, target.position);
        if(dist <= AttackRange)
        {
            Attack();
        }
        else
        {
            ReturnToFollow();
        }
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
