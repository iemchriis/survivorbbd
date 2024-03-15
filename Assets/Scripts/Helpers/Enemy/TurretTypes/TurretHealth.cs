using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : EnemyScript, IDamagable
{
    [SerializeField]private EnemyTurret turret;
    [SerializeField]private TurretConsole console;

    private void Start()
    {
        animator = GetComponent<Animator>();
        console = FindAnyObjectByType<TurretConsole>();
        turret = GetComponentInChildren<EnemyTurret>();
    }

    private void Update()
    {
        DebuffTimer();
    }

    public override void Death()
    {
        if (!IsDead())
        {

            StopAllCoroutines();
            base.Death();

            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            go.transform.SetParent(transform.parent);

            GameManager.Instance.RemoveEnemy(this);
            GameManager.Instance.CheckEnemyCount();

            if(turret.isHackable)
            {
                console.RemoveFromList(turret);
            }

            LevelGenerator.Instance.SpawnPowerup(transform);
            if(turret)
            Destroy(gameObject, 2);


        }
    }
}
