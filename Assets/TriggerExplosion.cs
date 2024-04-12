using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    public GameObject Explosion;
    private void OnTriggerEnter(Collider collision)
    {

        GameObject go = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        
    }
}
