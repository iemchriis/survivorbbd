using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class PlayerDataManager : MonoBehaviour
{

    public string initJson;
    public PlayerStats playerStats;
    public int currentWeapon;
    public static PlayerDataManager Instance { get; set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        InitializeData();
    }


    void InitializeData()
    {
        JsonData data;
        data = JsonMapper.ToObject(initJson);
        playerStats.health = int.Parse(data[0]["player_life"].ToString());
        playerStats.movementSpeed = float.Parse(data[0]["player_speed"].ToString());
    }



    public int GetPlayerHealth()
    {
        return playerStats.health;
    }

    public float GetPlayerSpeed()
    {
        return playerStats.movementSpeed;
    }

}





[System.Serializable]
public class PlayerStats
{
    public int health;
    public float movementSpeed;
}
