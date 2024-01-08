using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navmesh;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        navmesh = GetComponent <NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


        if (target != null)
        {
            navmesh.destination = target.position;
            transform.LookAt(target.position);
          //  transform.position = Vector3.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
        }
    }
}
