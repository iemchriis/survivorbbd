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
            LevelGenerator.Instance.SetPowerup(powerupIndex);
            other.GetComponent<PlayerTriggerHelper>().GoToInitPosition();
            GameObject.FindAnyObjectByType<DroneMovement>().ResetPositionToPlayer();
            LevelGenerator.Instance.spawnNewLevel();
        }
    }
}
