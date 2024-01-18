using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : CharacterBase
{
    private Transform target;
    private NavMeshAgent navmesh;
    public GameObject exp;
    
    public bool hasStatusEffect;
    [SerializeField]private float debuffDuration;

    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        navmesh = GetComponent <NavMeshAgent>();
    }

   

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        health -= damage;
        Death();
    }

    

    public override void TakeDamageOverTime(int damage, float duration, int tickTime)
    {
       debuffDuration = duration;
       
       StartCoroutine(DOT(damage, duration, tickTime));
    }


    IEnumerator DOT(int damage, float duration, int tickTime)
    {
        hasStatusEffect = true;
        while (debuffDuration > 0)
        {         
            
            health -= damage;
            yield return new WaitForSeconds(tickTime);
        }
        
        yield return null;
    }

    

    public override void Death()
    {
        if(health <=0 && !IsDead())
        {
            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            base.Death();
            navmesh.isStopped = true;
            //GameManager.Instance.playerTargeting.RemoveFromTargetList(this);
            GameManager.Instance.enemyCount--;
            //GameManager.Instance.CheckEnemyCount();
            LevelGenerator.Instance.SpawnPowerup(transform);
            GetComponent<Animator>().SetTrigger("isDead");
            Destroy(gameObject, 2);

        }

    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }

    void StartTime()
    {
        debuffDuration -= Time.deltaTime;
        if(debuffDuration <= 0)
        {
            hasStatusEffect = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (target != null && !IsDead())
        {
            navmesh.destination = target.position;
            transform.LookAt(target.position);
          //  transform.position = Vector3.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
        }
       
        if(hasStatusEffect)
        {
            StartTime();
        }
    }
}
