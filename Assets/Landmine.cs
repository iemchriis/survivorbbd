using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{

    public GameObject AOE;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject go = Instantiate(AOE, transform.position, Quaternion.identity);
            go.GetComponent<RocketExplosionAOE>().SetValues(20, 10);
            Destroy(gameObject);
        }
    }
}
