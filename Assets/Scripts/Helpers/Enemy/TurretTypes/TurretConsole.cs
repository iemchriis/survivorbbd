using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConsole : MonoBehaviour
{
    public EnemyTurret[] turrets;

    public float targetTime = 10f;
    public float currentTime;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            currentTime += Time.deltaTime;
            if(currentTime >= targetTime)
            {
                Debug.Log("Hacked");
                HackTurrets();
            }
        }
    }

    void HackTurrets()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].TargetName = "Enemy";
            turrets[i].tag = "Untagged";
            GameManager.Instance.enemyCount--;
        }
    }

    
}
