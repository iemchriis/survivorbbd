using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public enum DamageType
    {
        NORMAL,
        CRIT,
        SLOW,
        BURN,
        STUN,
        POISON
    }

    public string id;
    public int health;

    private bool isDead;

    public GameObject damageFX;
    public GameObject damageTxt;

    public bool IsDead()
    {
        return isDead;
    }

    
    public virtual void TakeDamage(int damage, DamageType type = DamageType.NORMAL)
    {
        health -= damage;

        if(damageFX != null)
        {
            ShowHitEffect();
        }

        if(damageTxt != null)
        {
            ShowDamageText(damage, type);
        }

        
    }

    protected void ShowHitEffect()
    {
        
        GameObject fx = Instantiate(damageFX, transform);
    
        Destroy(fx, 1);
    }

    protected void ShowDamageText(int damage, DamageType type)
    {
        GameObject go = Instantiate(damageTxt, transform.position, Quaternion.identity);
        TextMesh txt = go.GetComponent<TextMesh>();
        // set damage to text
        txt.text = "-" + damage.ToString();

        // set color type
        switch (type)
        {
            case DamageType.NORMAL:
                {
                    txt.color = Color.white;
                }
                break;
            case DamageType.BURN:
                {
                    Color orange = new Color(255, 165, 0);
                    txt.color = orange;
                }
                break;
            case DamageType.CRIT:
                {
                    txt.color = Color.red;
                }
                break;
            case DamageType.SLOW:
                {
                    Color brown = new Color(150, 75, 0);
                    txt.color = brown;
                }
                break;
            case DamageType.POISON:
                {
                    txt.color = Color.green;
                }
                break;
            case DamageType.STUN:
                {
                    txt.color = Color.yellow;   
                }
                break ;
        }
  
        // set position and rotation offset
        Vector3 offset = new Vector3(0, 3f, 0);
        txt.transform.localPosition += offset;
        txt.transform.localRotation = Quaternion.Euler(80, 0, 0);

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


   
}
