using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoint;

    public int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.enemyCount += spawnCount;
        StartCoroutine(CoSpawnWave());
    }


   public IEnumerator CoSpawnWave()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            int rand = Random.Range(0, spawnPoint.Length);
            GameObject go = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            go.transform.position = spawnPoint[rand].position;
            go.transform.parent = transform;
            yield return new WaitForSeconds(1);
        }
    }
  
}
