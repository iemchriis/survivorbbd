using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBoss : MonoBehaviour
{
    public GameObject projectilePrefab, summonPrefab;
    public Transform throwPoint;
    public Transform player;
    public float throwRate = 2f; // Time between throws in seconds
    private float throwTimer = 0f;
    public float throwSpeed = 10f;
    public int attackCount;
    public int requiredAttacksToSummon, summonCount;
    public BossType bossType;
    public Animator anim;

    private void Awake()
    {
        player = GameManager.Instance.targeting.transform.parent;
    }

    void Update()
    {
        throwTimer += Time.deltaTime;

        if (throwTimer >= throwRate)
        {
            if (attackCount < requiredAttacksToSummon)
            {
                ThrowProjectile();
            }
            else
            {
                Summon();
            }
            throwTimer = 0f; // Reset the timer
        }
        transform.LookAt(player);
    }

    public void SpawnMinions()
    {
        if (bossType == BossType.SPAWN)
        {
            for (int i = 0; i < summonCount; i++)
            {
                Vector3 randomPosition = Random.insideUnitSphere + transform.position;
                GameObject go = Instantiate(summonPrefab, transform.position, Quaternion.identity);
                go.transform.position = new Vector3(randomPosition.x, transform.position.y, randomPosition.z);
            }
        }
        else
        {



            // Spawn bullets with a spread
            for (int i = 0; i < 10; i++)
            {
                Rigidbody projectileRb = Instantiate(projectilePrefab.GetComponent<Rigidbody>(), throwPoint.position, throwPoint.rotation);

                float c = Random.Range(0, 90);
                if (projectileRb != null)
                {
                    Vector3 target = new Vector3(player.position.x, player.position.y, c);
                    Vector3 toPlayer = target - throwPoint.position;

                    // Calculate the time of flight using the y-component of the displacement and the gravity
                    float timeOfFlight = Mathf.Sqrt(2 * toPlayer.y / Mathf.Abs(Physics.gravity.y));

                    // Calculate the initial velocity needed for the projectile to reach the player
                    Vector3 throwVelocity = toPlayer.normalized * throwSpeed;

                    projectileRb.AddForce(throwVelocity, ForceMode.VelocityChange);

                }
            }
           
        }
    }


    void ThrowProjectile()
    {
        anim.SetBool("Attack 01", true);
        attackCount++;
        // Additional projectile setup if needed
    }

    void Summon()
    {
        anim.SetBool("Summon", true);
        attackCount = 0;
        GameManager.Instance.enemyCount += summonCount;
    }


    public void Throw()
    {
        Rigidbody projectileRb = Instantiate(projectilePrefab.GetComponent<Rigidbody>(), throwPoint.position, throwPoint.rotation);

        if (projectileRb != null)
        {
            Vector3 toPlayer = player.position - throwPoint.position;

            // Calculate the time of flight using the y-component of the displacement and the gravity
            float timeOfFlight = Mathf.Sqrt(2 * toPlayer.y / Mathf.Abs(Physics.gravity.y));

            // Calculate the initial velocity needed for the projectile to reach the player
            Vector3 throwVelocity = toPlayer.normalized * throwSpeed;

            projectileRb.AddForce(throwVelocity, ForceMode.VelocityChange);

        }
    }

    public void StopAnim()
    {
        anim.SetBool("Attack 01", false);
    }


    public void StopSummon()
    {
        anim.SetBool("Summon", false);
    }
}

public enum BossType
{
    SPAWN,
    SCATTER
}