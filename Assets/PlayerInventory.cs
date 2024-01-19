using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject Shield;
    public void EnableShield()
    {
        Shield.SetActive(true);
    }

    public void AddHealth()
    {
        GetComponent<PlayerHealth>().health += 10;
        GetComponent<PlayerHealth>().hpBar.value += 10;
        GetComponent<PlayerHealth>().hpBar.maxValue += 10;
    }

    public void AddSpeed()
    {
        GetComponent<PlayerMovement>().moveSpeed += 1;
    }
}
