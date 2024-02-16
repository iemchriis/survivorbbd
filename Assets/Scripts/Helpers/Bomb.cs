using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector3 target;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public float maxAngleOffset = 30f;

    private Rigidbody rb;

    public GameObject AOE;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Launch();
    }


    public void setTarget(Vector3 tempTarget)
    {
        target = tempTarget;
    }

    public void Launch()
    {
        Vector3 direction = (target - transform.position).normalized;
        float randomAngle = Random.Range(-maxAngleOffset, maxAngleOffset);
        Vector3 randomDirection = Quaternion.Euler(0f, randomAngle, 0f) * direction;

        float speed = Random.Range(minSpeed, maxSpeed);
        Vector3 velocity = randomDirection * speed;

        rb.velocity = velocity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            GameObject go =  Instantiate(AOE, transform.position, Quaternion.identity);
            go.GetComponent<RocketExplosionAOE>().SetValues(20, 10);
            Destroy(gameObject);
        }
    }
}
