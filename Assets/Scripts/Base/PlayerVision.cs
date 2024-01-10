using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public List<EnemyScript> targets;

    public BaseWeapon weapon;    
    public GameObject nearestEnemy;


    public void CalculateNearest()
    {
        if (targets.Count <= 0)
        {
            weapon.canFire = false;
            return;
        }
           

        targets.Sort((x,y) => Vector3.Distance(transform.position, x.transform.position).CompareTo(Vector3.Distance(transform.position, y.transform.position)));


        nearestEnemy = targets[0].gameObject;
        weapon.canFire = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           EnemyScript enemy = other.GetComponent<EnemyScript>();

            if(enemy != null)
            {
                if (targets.Contains(enemy))
                    return;

                targets.Add(enemy); 
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                targets.Remove(enemy);
            }

        }
    }

    private void Update()
    {
        CalculateNearest();
    }
}
