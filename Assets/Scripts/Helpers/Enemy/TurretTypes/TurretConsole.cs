using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretConsole : MonoBehaviour
{
    public List<EnemyTurret> enemyTurrets = new List<EnemyTurret>();
    public Slider consoleSlider;
    public float targetTime = 10f;
    public float currentTime;
    public bool isHacked;

    private void Start()
    {
        consoleSlider.maxValue = targetTime;
        consoleSlider.minValue = currentTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(isHacked)
                return;

            currentTime += Time.deltaTime;
            consoleSlider.value = currentTime;
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
        for (int i = 0; i < enemyTurrets.Count; i++)
        {
            enemyTurrets[i].ChangeTarget();
            GameManager.Instance.enemyCount--;
        }
    }

    public void RemoveFromList(EnemyTurret turret)
    {
        enemyTurrets.Remove(turret);    
    }

    
}
