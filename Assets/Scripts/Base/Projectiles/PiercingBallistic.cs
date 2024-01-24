using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingBallistic : BaseProjectile
{
    public bool canPierce;
    [SerializeField] private int pierceCount;
    [SerializeField] private int pierceLevel;


    protected override void Awake()
    {
        base.Awake();
        AudioManager.Instance.PlaySFX("Gunshot");
        pierceCount = 3;

    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            pierceCount--;
            Debug.Log("Pierce enemy");
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            if (pierceCount <= 0)
            {
                Debug.Log("Pierce Ended");
                Destroy(gameObject);
            }
        }
    }
}
