using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : BaseProjectile
{
    [SerializeField]private float bulletDropOff;

    private Vector3 startPos;

    private void Start()
    {
        bulletDropOff = 8f;
        startPos = transform.position;
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        CheckRange();

        //if(Vector3.Distance(startPos, transform.position) > bulletDropOff)
        //{
        //    rb.velocity = Vector3.zero;
        //    Destroy(this.gameObject);
        //}
    }

    void CheckRange()
    {
        float dist = Vector3.Distance(startPos, transform.position);

        

        if(dist > 8f)
        {
            Debug.Log("Range Dropoff");
            rb.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }


    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}
