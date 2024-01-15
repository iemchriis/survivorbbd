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


    public override void TakeDamage()
    {
        base.TakeDamage();
        health--;
        Death();
    }

    public override void Death()
    {
        if(health <=0 && !IsDead())
        {
            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            base.Death();
            navmesh.isStopped = true;
            PlayerVision vision = FindObjectOfType<PlayerVision>();
            vision.nearestEnemy = null;
            vision.targets.Remove(this);
            navmesh.velocity = Vector3.zero;
        
            GameManager.Instance.enemyCount--;
            GetComponent<Animator>().SetTrigger("isDead");
            Destroy(gameObject, 2);

        }

    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet" && !IsDead())
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
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
