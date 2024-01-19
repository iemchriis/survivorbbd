using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator Instance { get; set; }

    public GameObject[] levelPrefabs;
    public GameObject[] Powerups;
    public GameObject bossLevel;
    private int currentPowerup;
    private int currentLevel;
    public int stagesBeforeBoss;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        currentPowerup = Random.Range(0, Powerups.Length);
    }


    public void spawnNewLevel()
    {
        currentLevel++;
        GameManager.Instance.DeleteLevel();
        GameManager.Instance.SetCurrentLevel(null);
        GameObject level = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
        if (currentLevel < stagesBeforeBoss)
        {

            GameObject go = Instantiate(level, new Vector3(45.38131f, -9.046906f, 4.755415f), Quaternion.identity);
        }
        else
        {
            currentLevel = 0;
            GameObject go = Instantiate(bossLevel, new Vector3(45.38131f, -9.046906f, 4.755415f), Quaternion.identity);
        }
    }


    public void SpawnPowerup(Transform position)
    {
        if (GameManager.Instance.enemyCount <= 0)
        {
            GameObject powerup = Powerups[currentPowerup];

            GameObject go = Instantiate(powerup, position.position, Quaternion.identity);
            go.transform.position = new Vector3(position.position.x, 1, position.position.z);
            
        }

    }

   
}
