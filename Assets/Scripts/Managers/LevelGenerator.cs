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

    private Level activeLevel;

    public GameObject[] levelPrefabs;
    public GameObject[] Powerups;
    public GameObject bossLevel, Popup;


    private int currentPowerup;
    private int currentLevel;
    // public int stagesBeforeBoss;

    private Vector3 spawnPos = new Vector3(0, 0, 0); ///new Vector3(45.38131f, -9.046906f, 4.755415f);
    // Start is called before the first frame update
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

    public void SpawnNewLevel()
    {
        
        currentLevel++;
        GameManager.Instance.DeleteLevel();
        GameManager.Instance.SetCurrentLevel(null);
        
        //GameObject level = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
        activeLevel = currentSequence.Sequence[currentLevel].GetLevelFromList();
        //Vector3 rot = new Vector3(0, 90, 0);
        GameObject go = Instantiate(activeLevel.gameObject, spawnPos, activeLevel.transform.rotation);

        Debug.Log(activeLevel.name);
        navMeshSurface.RemoveData();
        Invoke(nameof(BuildLevel), 0.1f);

    }

    public void BuildLevel()
    {
        navMeshSurface.BuildNavMesh();
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
