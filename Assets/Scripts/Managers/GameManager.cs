using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public WeaponSelection selection;
    public PlayerVision targeting;
    public int enemyCount;


    private Level currentLevel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
       selection.SelectWeapon();
    }

    public void RemoveEnemy(EnemyScript enemy)
    {
        targeting.RemoveFromTargetList(enemy);
        enemyCount--;

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
