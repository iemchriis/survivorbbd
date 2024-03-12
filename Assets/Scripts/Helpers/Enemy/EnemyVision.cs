using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField]private EnemyMovement enemyMovement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Friendly"))
        {
            enemyMovement.target = other.transform;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            enemyMovement.target = other.transform;
            if (enemyMovement.target == null)
            {
                enemyMovement.SetTargetToPlayer();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {

            enemyMovement.SetTargetToPlayer();
            
        }
    }
}
