using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterBase
{
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        health -=damage;
        if(health <= 0)
        {
            Death();
            GameUIManager.Instance.ShowGameOver();
        }
    }


   
}
