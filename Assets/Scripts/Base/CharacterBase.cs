using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public string id;
    public int health;

    bool isDead;

    public GameObject damageFX;

    public bool IsDead()
    {
        return isDead;
    }

    
    public virtual void TakeDamage()
    {
        GameObject go = Instantiate(damageFX, transform);
        Destroy(go, 1);
    }

    public virtual void Death()
    {
        GetComponent<BoxCollider>().enabled = false;    
        isDead = true;
    }


    public virtual void OnTriggerEnter(Collider other)
    {

    }
}
