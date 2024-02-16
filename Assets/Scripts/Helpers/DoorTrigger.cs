using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int powerupIndex;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameManager.Instance.enemyCount > 0)
                return;

            LevelGenerator.Instance.SetPowerup(powerupIndex);
            LevelGenerator.Instance.SpawnNewLevel();

            other.GetComponent<PlayerTriggerHelper>().GoToNextSpawn();
        }
    }
}
