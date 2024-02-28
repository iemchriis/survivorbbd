using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : CharacterBase
{
    public Slider hpBar;
    private void Start()
    {
        health = PlayerDataManager.Instance.GetHealthValue();

        if(hpBar != null)
        {
            hpBar.maxValue = PlayerDataManager.Instance.GetHealthValue();
            hpBar.value = PlayerDataManager.Instance.GetHealthValue();
        }
        
    }

    public override void TakeDamage(int damage, DamageType type = DamageType.NORMAL)
    {
        base.TakeDamage(damage);
       
        hpBar.value -= damage;
        if(health <= 0)
        {
            Death();
            AudioManager.Instance.PlaySFX("Hit");
            GameUIManager.Instance.ShowGameOver();
        }
    }


   
}
