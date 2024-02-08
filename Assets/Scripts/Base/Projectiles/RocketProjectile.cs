using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : BaseProjectile
{
    [SerializeField] private GameObject aoeEffect;

    private float explosionRadius;

    private void Start()
    {
        AudioManager.Instance.PlaySFX("Rocket");

    }

    public void SetSplashDamageValues(int damage, float radius)
    {
        aoeEffect.GetComponent<RocketExplosionAOE>().SetValues(damage, radius);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            rb.velocity = Vector3.zero;
            aoeEffect.SetActive(true);
            other.GetComponent<EnemyScript>().TakeDamage(damage, isCrit);
            Debug.Log("Direct Hit" + damage);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
