using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingBallistic : BaseProjectile
{
    
    [SerializeField] private int pierceCount;
    


    protected override void Awake()
    {
        base.Awake();
        AudioManager.Instance.PlaySFX("Gunshot");
        

    }

    public void SetPierceLevel(int pierceCount)
    {
        this.pierceCount = pierceCount;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();

            if(enemy != null)
            {
                pierceCount--;
                enemy.TakeDamage(damage, CheckIfCrit());
                if (pierceCount <= 0)
                {
                   
                    Destroy(gameObject);
                }
            }

           
        }
    }
}
