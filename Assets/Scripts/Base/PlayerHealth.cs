using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : CharacterBase
{
    public Slider hpBar;
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        health -=damage;
        hpBar.value -= damage;
        if(health <= 0)
        {
            Death();
            GameUIManager.Instance.ShowGameOver();
        }
    }


   
}
