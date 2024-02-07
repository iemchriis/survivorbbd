using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class PlayerDataManager : MonoBehaviour
{

    public string initJson;
    public PlayerStats playerStats;
    public int currentWeapon;

    public int premiumCoins;
    public int playerCoins;
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
        if (PlayerPrefs.HasKey("DATA"))
        {
            JsonData data;
            initJson = PlayerPrefs.GetString("DATA");
            data = JsonMapper.ToObject(initJson);
            playerStats.health = int.Parse(data["health"].ToString());
            playerStats.movementSpeed = float.Parse(data["movementSpeed"].ToString());
            playerStats.critChance = float.Parse(data["critChance"].ToString());
            playerStats.armor = float.Parse(data["armor"].ToString());
            playerStats.droneDamage = int.Parse(data["droneDamage"].ToString());
            playerStats.droneROF = float.Parse(data["droneROF"].ToString());
            playerStats.droneDamageType = int.Parse(data["droneDamageType"].ToString());
            playerCoins = PlayerPrefs.GetInt("PLAYER_COINS");
        }

    }

    public void AddPlayerCoins()
    {
        playerCoins++;
        PlayerPrefs.SetInt("PLAYER_COINS", playerCoins);
    }

    public void DeductCoins(int cost)
    {
        playerCoins -= cost;
        PlayerPrefs.SetInt("PLAYER_COINS", playerCoins);
    }


    public int GetPlayerCoins()
    {
        return playerCoins;
    }

    public double GetCritChance()
    {
        return playerStats.critChance;
    }

    public double GetArmor()
    {
        return playerStats.armor;
    }

    public int GetDroneDamage()
    {
        return playerStats.droneDamage;
    }

    public double GetDroneROF()
    {
        return playerStats.droneROF;
    }

    public int GetHealthValue()
    {
        int multiplier = 10 * playerStats.health;
        return 100 + multiplier;
    }

    public float GetArmorValue()
    {
        float multiplier = (float)(0.5f * playerStats.armor);
        return 0 + multiplier;

    }

    public double GetSpeedValue()
    {
        float multiplier = (float)(0.25f * playerStats.movementSpeed);
        return 3 + multiplier;
    }

    public double GetCritChanceValue()
    {
        float multiplier = (float)(0.1f * playerStats.critChance);
        return 0 + multiplier;
    }


    public int GetStatCost(int level)
    {
        int multiplier = level * 100;
        return 1000 + multiplier;
    }

    public int GetDroneDamageValue()
    {
        int multiplier = 1 * playerStats.droneDamage;
        return 1 + multiplier;
    }

    public double GetDroneROFValue()
    {
        float multiplier = (float)(0.1f * playerStats.droneROF);
        return 2 - multiplier;
    }




    public void SetPlayerStats(int _health, float _moveSpeed, float _critChance, float _armor, int _droneDamage, float _droneROF)
    {
        playerStats.health = _health;
        playerStats.movementSpeed = _moveSpeed;
        playerStats.critChance = _critChance;
        playerStats.armor = _armor;
        playerStats.droneDamage = _droneDamage;
        playerStats.droneROF = _droneROF;

        string jsonString = JsonMapper.ToJson(playerStats);
        initJson = jsonString;
        PlayerPrefs.SetString("DATA", jsonString);
    }

}





[System.Serializable]
public class PlayerStats
{
    public int health;
    public double movementSpeed, critChance, armor;

    public int droneDamage, droneDamageType;
    public double droneROF;
}
