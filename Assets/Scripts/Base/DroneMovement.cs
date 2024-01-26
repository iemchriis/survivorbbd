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

    public void ResetPositionToPlayer()
    {
        transform.position = new Vector3(player.position.x+ 3.5f, player.position.y, player.position.z - 3.5f);
    }

}
