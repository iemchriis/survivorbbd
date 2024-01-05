using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform spawnPoint;

    public int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoSpawnWave());
    }


    IEnumerator CoSpawnWave()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            GameObject go = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            go.transform.position = spawnPoint.position;
            yield return new WaitForSeconds(1);
        }
    }
  
}
