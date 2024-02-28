using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour, ISlowed, IStunned
{
    private Transform target;
    private NavMeshAgent navmesh;
    

    private EnemyScript health;
    private float debuffDuration;

    public NavMeshAgent Navmesh { get => navmesh;}
    

    private void Start()
    {
        health = GetComponent<EnemyScript>();
        
        target = GameManager.Instance.targeting.transform.parent;
        navmesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GoToTarget();
    }

  

    void GoToTarget()
    {
        if (target != null && !health.IsDead())
        {
            if (navmesh != null)
            {
                navmesh.destination = target.position;
            }
            transform.LookAt(target.position);

        }
    }

    public void Attack()
    {

    }

    public void ApplySlowEffect(int debuffAmount, float debuffDuration)
    {
        StartCoroutine(ApplySlowEffectAsync(debuffAmount, debuffDuration));
    }

    public IEnumerator ApplySlowEffectAsync(int debuffAmount, float debuffDuration)
    {
        var initSpeed = navmesh.speed;

        navmesh.speed -= debuffAmount;
        yield return new WaitForSeconds(debuffDuration);
        navmesh.speed = initSpeed;
    }

    public void ApplyStun(float stunDuration)
    {
        StartCoroutine(ApplyStunAsync(stunDuration));
    }

    public IEnumerator ApplyStunAsync(float stunDuration)
    {
        navmesh.isStopped = true;
        yield return new WaitForSeconds(stunDuration);
        navmesh.isStopped = false;
    }
}
