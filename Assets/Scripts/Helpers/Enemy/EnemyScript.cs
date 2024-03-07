using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyScript: CharacterBase, IDamagable
{
    private EnemyMovement movement;
    private Animator animator;
    
    public GameObject exp;
    protected bool hasDps;
    protected float debuffDuration;

    public GameObject burnEffect;
   

    public Animator Animator { get => animator; }

    void Start()
    {
        movement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        if (hpSlider != null)
        {
            hpSlider.maxValue = health;
            hpSlider.value = health;
        }

    }

    void Update()
    {
        DebuffTimer();
    }

    protected void DebuffTimer()
    {

        if(hasDps)
        {
            debuffDuration -= Time.deltaTime;
            if (debuffDuration <= 0)
            {
                hasDps = false;
            }
        }
 
    }




    public void TakeDamage(int damage, DamageType type = DamageType.NORMAL)
    {
        health -= damage;
             
       
        ShowHitEffect();
        ShowDamageText(damage, type);

        if(health <= 0)
        {
            Death();
        }
    }

    

    public void TakeDamageOverTime(int damage, float duration, int tickTime)
    {
       debuffDuration = duration;
       
       StartCoroutine(DOT(damage, duration, tickTime));
    }


    protected IEnumerator DOT(int damage, float duration, int tickTime)
    {
        hasDps = true;
        burnEffect.SetActive(true);
        while (debuffDuration > 0)
        {

            TakeDamage(damage, DamageType.BURN);
            Debug.Log("Burning");
            yield return new WaitForSeconds(tickTime);
        }
        burnEffect.SetActive(false);
        yield return null;
    }

    

    public override void Death()
    {
        if(!IsDead())
        {

            StopAllCoroutines();
            base.Death();

            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            go.transform.SetParent(transform.parent);

            if (movement != null) { movement.Navmesh.isStopped = true; }

            GameManager.Instance.RemoveEnemy(this); 
            GameManager.Instance.CheckEnemyCount();

            LevelGenerator.Instance.SpawnPowerup(transform);
            animator.SetTrigger("isDead");
            Destroy(gameObject, 2);
            

        }

    }

   

  
  

   
   

}
