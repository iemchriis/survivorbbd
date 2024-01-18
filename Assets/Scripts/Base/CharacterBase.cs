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

    
    public virtual void TakeDamage(int damage)
    {
        GameObject go = Instantiate(damageFX, transform);
        Destroy(go, 1);
    }

    public virtual void TakeDamageOverTime(int damage, float duration, int tickTime)
    {

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
