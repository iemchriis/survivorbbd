using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConsole : MonoBehaviour
{
    public EnemyTurret[] turrets;

    public float targetTime = 10f;
    public float currentTime;
    public bool isHacked;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(isHacked)
                return;

            currentTime += Time.deltaTime;
            if(currentTime >= targetTime)
            {
                Debug.Log("Hacked");
                HackTurrets();
                isHacked = true;
            }
        }
    }

    void HackTurrets()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].ChangeTarget();
            GameManager.Instance.enemyCount--;
        }
    }

    
}
