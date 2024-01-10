using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float projectileVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        projectileVelocity = 30f;

        Destroy(gameObject, 10f);
    }


    public void ShootProjectTile(Vector3 direction)
    {
        rb.AddForce(direction * projectileVelocity, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
        }
    }
}
