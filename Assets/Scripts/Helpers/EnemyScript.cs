using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : CharacterBase
{
    private Transform target;
    private NavMeshAgent navmesh;
    public GameObject exp;
    // Start is called before the first frame update
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

    public override void Death()
    {
        if(health <=0 && !IsDead())
        {
            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            base.Death();
            navmesh.isStopped = true;
            GameManager.Instance.playerTargeting.RemoveFromTargetList(this);
            GameManager.Instance.enemyCount--;
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




    // Update is called once per frame
    void Update()
    {

        if (target != null && !IsDead())
        {
            navmesh.destination = target.position;
            transform.LookAt(target.position);
          //  transform.position = Vector3.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
        }
    }
}
