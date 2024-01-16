using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTargeting : MonoBehaviour
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


        targets.Sort((x, y) => Vector3.Distance(transform.position, x.transform.position).CompareTo(Vector3.Distance(transform.position, y.transform.position)));


        nearestEnemy = targets[0].gameObject;
        weapon.canFire = true;
    }

    public void RemoveFromTargetList(EnemyScript enemy)
    {
        targets.Remove(enemy);
        nearestEnemy = null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();

            if (enemy != null)
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
                //targets.Remove(enemy);
            }

        }
    }

    private void Update()
    {
        CalculateNearest();
        CheckIfDead();
        LookAtEnemy();
    }

    void LookAtEnemy()
    {
        if (nearestEnemy == null)
        {
            transform.LookAt(transform.forward);
        }
        else
        {
            Vector3 enemyDirection = nearestEnemy.transform.position;

            transform.LookAt(enemyDirection);
        }



    }

    void CheckIfDead()
    {
        foreach (var target in targets)
        {
            var enemy = target.GetComponent<EnemyScript>();
            if (enemy.IsDead())
            {
                RemoveFromTargetList(enemy);    
            }
        }


        if (nearestEnemy == null)
            return;

        var nearest = nearestEnemy.GetComponent<EnemyScript>();

        if(nearest.IsDead())
        {
            RemoveFromTargetList(nearest);
        }
    }
}
