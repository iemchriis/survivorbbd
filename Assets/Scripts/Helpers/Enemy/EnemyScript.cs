using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyScript : CharacterBase
{
    [SerializeField]private EnemyMovement movement;
    private Animator animator;
    
    public GameObject exp;
    public int damage;
    public Slider hpSlider;
    public bool hasDps;


    [SerializeField]private GameObject burnEffect;
    private float debuffDuration;

    public Animator Animator { get => animator; }

    void Start()
    {
        animator = GetComponent<Animator>();
        if (hpSlider != null)
        {
            hpSlider.maxValue = health;
            hpSlider.value = health;
        }

    }

    void Update()
    {
        if (hasDps)
        {
            DebuffTimer();
        }
    }

    void DebuffTimer()
    {
        debuffDuration -= Time.deltaTime;
        if (debuffDuration <= 0)
        {
            hasDps = false;
        }
    }




    public override void TakeDamage(int damage, DamageType type = DamageType.NORMAL)
    {
        base.TakeDamage(damage, type);
             
        if (hpSlider != null) { hpSlider.value -= damage; }
        if(health <= 0)
        {
            Death();
        }
    }

    

    public override void TakeDamageOverTime(int damage, float duration, int tickTime)
    {
       debuffDuration = duration;
       
       StartCoroutine(DOT(damage, duration, tickTime));
    }


    IEnumerator DOT(int damage, float duration, int tickTime)
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

   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

  

   
   

}
