using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : CharacterBase, IDebuff
{
    private Transform target;
    private NavMeshAgent navmesh;
    public GameObject exp;
    public int damage;
    public UnityEngine.UI.Slider hpSlider;

    
    public bool hasStatusEffect;


    [SerializeField]private GameObject burnEffect;
    private float debuffDuration;

    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        navmesh = GetComponent <NavMeshAgent>();
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }

   

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        health -= damage;
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
            
            health -= damage;
            Debug.Log("Burning");
            yield return new WaitForSeconds(tickTime);
        }
        burnEffect.SetActive(false);
        yield return null;
    }

    

    public override void Death()
    {
        if(health <=0 && !IsDead())
        {
            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            go.transform.parent = transform.parent;
            base.Death();
            GameManager.Instance.targeting.RemoveFromTargetList(this);
            GameManager.Instance.enemyCount--;
            GameManager.Instance.CheckEnemyCount();
            LevelGenerator.Instance.SpawnPowerup(transform);
            GetComponent<Animator>().SetTrigger("isDead");
            Destroy(gameObject, 2);
            if (navmesh != null) { navmesh.isStopped = true; }

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


    // Update is called once per frame
    void Update()
    {

        if (target != null && !IsDead())
        {
            if (navmesh != null)
            {
                navmesh.destination = target.position;
            }
            transform.LookAt(target.position);
          //transform.position = Vector3.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
        }
       
        if(hasStatusEffect)
        {
            StartTime();
        }
    }

    public void ApplyEffect(int debuffAmount, float debuffDuration)
    {
        StartCoroutine(ApplyEffectAsync(debuffAmount, debuffDuration));
    }

    public IEnumerator ApplyEffectAsync(int debuffAmount, float debuffDuration)
    {
        var ogSpeed = navmesh.speed;

        navmesh.speed -= debuffAmount;
        yield return new WaitForSeconds(debuffDuration);
        navmesh.speed = ogSpeed;
    }
}
