using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField]private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Friendly"))
        {
            var player = other.GetComponent<IDamagable>();
            if(player != null)
            {
                Debug.Log("Player Hit");
                player.TakeDamage(damage);
            }
        }
    }
}
