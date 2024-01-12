using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private StageSpawner spawner;

    public int enemyCount;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(enemyCount <= 0)
        {
            enemyCount = spawner.spawnCount;
            StartCoroutine(spawner.CoSpawnWave());
        }
    }
}
