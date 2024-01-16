using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;

    private Vector3 destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        destination = player.position;
        agent.SetDestination(destination);
    }

    void FollowPlayer()
    {
        if (agent != null)
            return;


    }

}
