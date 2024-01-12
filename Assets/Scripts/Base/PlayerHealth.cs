using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterBase
{
    


    public override void TakeDamage()
    {
        base.TakeDamage();
        health--;
        if(health <= 0)
        {
            Death();
            GameUIManager.Instance.ShowGameOver();
        }
    }


   
}
