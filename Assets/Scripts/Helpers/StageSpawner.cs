using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoint;

    public float waitTime = 1;

    public int spawnCount;
  
    public void StartSpawnWave()
    {

        //StartCoroutine(CoSpawnWave());
        for (int i = 0; i < spawnCount; i++)
        {
            int rand = Random.Range(0, spawnPoint.Length);
            GameObject go = Instantiate(enemyPrefab, GetRandomWavePosition(rand), Quaternion.identity);
            //go.transform.position = GetRandomWavePosition(rand);
            go.transform.parent = transform;
            Debug.Log("Spawn Wave");
            GameManager.Instance.enemyCount++;
            //yield return new WaitForSeconds(waitTime);
        }
    }


    Vector3 GetRandomWavePosition(int rand)
    {
        Vector3 newPos = Random.insideUnitSphere * 2 + spawnPoint[rand].position;
        newPos.y = spawnPoint[rand].position.y;
        return newPos;
    }


   public IEnumerator CoSpawnWave()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            int rand = Random.Range(0, spawnPoint.Length);
            GameObject go = Instantiate(enemyPrefab, GetRandomWavePosition(rand), Quaternion.identity);
            //go.transform.position = GetRandomWavePosition(rand);
            go.transform.parent = transform;
            Debug.Log("Spawn Wave");
            GameManager.Instance.enemyCount++;
            yield return new WaitForSeconds(waitTime);
        }
    }
  
}
