using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour, ISlowed, IStunned
{
    public EnemyType enemyType;
    public float distanceToChase;
    public Transform target;
    private NavMeshAgent navmesh;
    private EnemyScript health;
    
    public NavMeshAgent Navmesh { get => navmesh;}
    public Transform Target { get => target; }
    public EnemyScript Health { get => health; }

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
                if (enemyType == EnemyType.CHASE)
                {
                    navmesh.SetDestination(target.position);
                }

                if(enemyType == EnemyType.PATROL)
                {
                    float distance = Vector3.Distance(transform.position, target.position);

                    if(distance < distanceToChase)
                    {
                        navmesh.destination = target.position;
                    }
                }
                Vector3 fleeDirection = transform.position - target.position;

                if (enemyType == EnemyType.FLEE)
                {
                    Debug.Log(fleeDirection.magnitude < 4.0);
                    if (fleeDirection.magnitude < 4.0)
                    {
                        // Calculate the target position by adding the flee direction to the AI's position
                        Vector3 dirtoPlayer = transform.position - target.position;

                        Vector3 targetPosition = transform.position + dirtoPlayer;

                        // Move the AI to the target position
                        navmesh.SetDestination(targetPosition);
                    }
                }




            }
            transform.LookAt(target.position);

        }
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


public enum EnemyType
{
    CHASE,
    PATROL,
    FLEE

}