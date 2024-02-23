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
    int attackCount;
    public int requiredAttacksToSummon, summonCount;
    public Animator anim;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerTriggerHelper>().transform;
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
    }

    public void SpawnMinions()
    {
        for(int i = 0; i < summonCount; i++ )
        {
            Vector3 randomPosition = Random.insideUnitSphere + transform.position;
            GameObject go = Instantiate(summonPrefab, transform.position, Quaternion.identity);
            go.transform.position = new Vector3(randomPosition.x, transform.position.y, randomPosition.z);
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

