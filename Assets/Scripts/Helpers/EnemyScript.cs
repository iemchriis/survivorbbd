using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyScript : CharacterBase, ISlowed, IStunned
{
    private Transform target;
    private NavMeshAgent navmesh;
    private Animator animator;
    public GameObject exp;
    public int damage;
    public Slider hpSlider;

    
    public bool hasStatusEffect;


    [SerializeField]private GameObject burnEffect;
    private float debuffDuration;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        navmesh = GetComponent <NavMeshAgent>();

        if(hpSlider != null)
        {
            hpSlider.maxValue = health;
            hpSlider.value = health;
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
        hasStatusEffect = true;
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

            if (navmesh != null) { navmesh.isStopped = true; }

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

    void StartTime()
    {
        debuffDuration -= Time.deltaTime;
        if(debuffDuration <= 0)
        {
            hasStatusEffect = false;
        }
    }


   
    void Update()
    {

        if (target != null && !IsDead())
        {
            if (navmesh != null)
            {
                navmesh.destination = target.position;
            }
            transform.LookAt(target.position);
          
        }
       
        if(hasStatusEffect)
        {
            StartTime();
        }
    }

    public void ApplySlowEffect(int debuffAmount, float debuffDuration)
    {
        StartCoroutine(ApplySlowEffectAsync(debuffAmount, debuffDuration));
    }

    public IEnumerator ApplySlowEffectAsync(int debuffAmount, float debuffDuration)
    {
        var ogSpeed = navmesh.speed;

        navmesh.speed -= debuffAmount;
        yield return new WaitForSeconds(debuffDuration);
        navmesh.speed = ogSpeed;
    }

    public void ApplyStun(float stunDuration)
    {
        StartCoroutine(ApplyStunAsync(stunDuration));
    }

    public IEnumerator ApplyStunAsync(float stunDuration)
    {
        navmesh.isStopped = true;
        yield return new WaitForSeconds(stunDuration);
        navmesh.isStopped = false;
    }
}
