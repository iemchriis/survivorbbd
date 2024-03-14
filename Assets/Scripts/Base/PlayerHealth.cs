using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : CharacterBase, IDamagable
{
    
    private void Start()
    {
        health = PlayerDataManager.Instance.GetHealthValue();

        if(hpSlider != null)
        {
            hpSlider.maxValue = PlayerDataManager.Instance.GetHealthValue();
            hpSlider.value = PlayerDataManager.Instance.GetHealthValue();
        }
        
    }

    public void TakeDamage(int damage, DamageType type = DamageType.NORMAL)
    {
        health -= damage;
       
        hpSlider.value -= damage;
        if(health <= 0)
        {
            Death();
            AudioManager.Instance.PlaySFX("Hit");
            // GameUIManager.Instance.ShowGameOver();
            Invoke("LoadBack", 3);
            gameObject.SetActive(false);
        }
    }


    void LoadBack()
    {
        SceneManager.LoadScene("WeaponSelection");
    }

    public void AddHealth(int value)
    {
        Debug.Log("Health");
        health += value;

        hpSlider.value += value;
    }

    public void TakeDamageOverTime(int damage, float duration, int tickTime)
    {
        throw new System.NotImplementedException();
    }
}
