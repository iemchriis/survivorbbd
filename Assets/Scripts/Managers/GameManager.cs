using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerVision targeting;
    public BaseWeapon currentWeapon;
    public WeaponHolder playerWeaponHolder;
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
        Time.timeScale = 0;
    }

    public void SelectBallisticWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<BallisticWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>();
        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectLaserWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<LaserWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<LaserWeapon>();
        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
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
