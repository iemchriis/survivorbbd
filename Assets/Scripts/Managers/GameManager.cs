using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerVision playerTargeting;
    public int enemyCount;


    private Level currentLevel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    public void CheckEnemyCount()
    {
        if(enemyCount <= 0)
        {
            currentLevel.NewLevel();
        }
    }

    public void DeleteLevel()
    {
        Destroy(currentLevel.gameObject);
    }


    public void SetCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    
}
