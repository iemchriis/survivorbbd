using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerTriggerHelper>().GoToInitPosition();
            GameObject.FindAnyObjectByType<DroneMovement>().ResetPositionToPlayer();
            LevelGenerator.Instance.spawnNewLevel();
        }
    }
}
