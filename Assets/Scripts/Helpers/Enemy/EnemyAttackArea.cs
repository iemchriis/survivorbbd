using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField]private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerHealth>();
            if(player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
