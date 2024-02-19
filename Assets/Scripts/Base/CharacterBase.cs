using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public string id;
    public int health;

    bool isDead;

    public GameObject damageFX;
    public GameObject damageTxt;

    public bool IsDead()
    {
        return isDead;
    }

    
    public virtual void TakeDamage(int damage, bool isCrit=false)
    {
        health -= damage;

        if(damageFX != null)
        {
            ShowHitEffect();
        }

        if(damageTxt != null)
        {
            ShowDamageText(damage, isCrit);
        }

        
    }

    protected void ShowHitEffect()
    {
        Debug.Log("Show Dmg");
        GameObject fx = Instantiate(damageFX, transform);
    
        Destroy(fx, 1);
    }

    protected void ShowDamageText(int damage, bool isCrit)
    {
        GameObject txt = Instantiate(damageTxt, transform.position, Quaternion.identity);
        txt.GetComponent<TextMesh>().text = "-" + damage.ToString();

        if(isCrit)
        {
            txt.GetComponent<TextMesh>().color = Color.red;
        }

        Vector3 offset = new Vector3(0, 3f, 0);
        txt.transform.localPosition += offset;
        txt.transform.localRotation = Quaternion.Euler(80, 0, 0);

        Destroy(txt, 1);
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
