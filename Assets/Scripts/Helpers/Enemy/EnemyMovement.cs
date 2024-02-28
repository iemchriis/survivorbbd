using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour, ISlowed, IStunned
{
    public EnemyType enemyType;
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
<<<<<<< HEAD
    
=======
>>>>>>> 0e641eb0ad3a7e911c56c902721b63a037df5c58
    }

  

    void GoToTarget()
    {

        if (target != null && !health.IsDead())
        {
            if (navmesh != null)
            {
                if (enemyType == EnemyType.CHASE)
                {
                    navmesh.destination = target.position;
                }

                if(enemyType == EnemyType.PATROL)
                {
                    float distance = Vector3.Distance(transform.position, target.position);
                    Debug.Log(distance);
                    if(distance < 7)
                    {
                        navmesh.destination = target.position;
                    }
                }
            }
            transform.LookAt(target.position);

        }
    }

<<<<<<< HEAD
    
=======
    public void Attack()
    {

    }
>>>>>>> 0e641eb0ad3a7e911c56c902721b63a037df5c58

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
    PATROL

}