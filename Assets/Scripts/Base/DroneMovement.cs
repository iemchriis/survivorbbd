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

    public void ResetPositionToPlayer(Vector3 pos)
    {
        //StartCoroutine(CoResetPosition(pos));
        gameObject.SetActive(false);
        transform.position = pos;
        Invoke("Reposition", 0.2f);
    }

    void Reposition()
    {
        Debug.Log("Drone Repositioned");
        gameObject.SetActive(true);
    }

    IEnumerator CoResetPosition(Vector3 pos)
    {
       
        yield return new WaitForSeconds(2f);
        
        gameObject.SetActive(true);
    }

}
