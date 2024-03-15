using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator Instance { get; set; }

    //public LevelSequence[] sequences;

    public NavMeshSurface navMeshSurface;
    public LevelSequence currentSequence;

    public GameObject[] levelPrefabs;
    public GameObject[] Powerups;
    public GameObject bossLevel, Popup, Fade;


    private int currentPowerup;
    private int currentLevel;

    public Transform currentParent;

    private Level activeLevel;

    private Vector3 spawnPos = new Vector3(0, 0, 0); ///new Vector3(45.38131f, -9.046906f, 4.755415f);

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        currentPowerup = Random.Range(0, Powerups.Length);
        
        navMeshSurface.BuildNavMesh();
    }

    public void SetPowerup(int i)
    {
        currentPowerup = i;
    }
    public Transform GetActiveLevel()
    {
        return activeLevel.playerSpawn;
    }

    public Transform GetLevelParent()
    {
        return currentParent.transform;
    }


    public void SpawnNewLevel()
    {
        
        if(currentLevel >= currentSequence.Sequence.Count)
        {
            currentLevel = 1;
        }

        currentLevel++;
        GameManager.Instance.DeleteLevel();
        GameManager.Instance.SetCurrentLevel(null);
        Fade.SetActive(true);

        GetNewLevel();
        navMeshSurface.RemoveData();
        Invoke(nameof(BuildLevel), 0.1f);
        Invoke(nameof(SpawnEnemies), 0.5f);

    }

    void GetNewLevel()
    {

        Level newLevel = currentSequence.Sequence[currentLevel].GetLevelFromList();

        //while (activeLevel == newLevel)
        //{

        //    newLevel = currentSequence.Sequence[currentLevel].GetLevelFromList();
        //}

        activeLevel = newLevel;
        GameObject go = Instantiate(activeLevel.gameObject, spawnPos, activeLevel.transform.rotation);
        currentParent = go.transform;
    }

    private void BuildLevel()
    {
        navMeshSurface.BuildNavMesh();
      
    }

    private void SpawnEnemies()
    {
        GameManager.Instance.SpawnEnemiesOnLevel();
    }



    public void SpawnPowerup(Transform position)
    {
        if (GameManager.Instance.enemyCount <= 0)
        {
            GameObject powerup = Powerups[currentPowerup];
            StartCoroutine(CoShowNotif());
            GameObject go = Instantiate(powerup, position.position, Quaternion.identity);
            go.transform.position = new Vector3(position.position.x, 1, position.position.z);
        }

    }

    IEnumerator CoShowNotif()
    {
        Popup.SetActive(true);
        yield return new WaitForSeconds(2);
        Popup.SetActive(false);
    }

   
}
