using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public PlayerVision playerTargeting;
    public int enemyCount;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    
}
