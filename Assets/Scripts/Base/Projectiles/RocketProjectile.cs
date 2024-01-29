using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : BaseProjectile
{
    [SerializeField] private GameObject aoeEffect;

    private float explosionRadius;


    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            aoeEffect.SetActive(true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
