using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgradeModel : MonoBehaviour
{

    public PlayerValues playerStats;


    private void Start()
    {

        var playerData = PlayerDataManager.Instance.playerStats;

        playerStats.health = playerData.health;
        playerStats.speed = (int)playerData.movementSpeed;
        playerStats.critChance = (int)playerData.critChance;
        playerStats.armor = (int)playerData.armor;
        playerStats.droneDamage = playerData.droneDamage;
        playerStats.droneROF = (int)playerData.droneROF;
        playerStats.droneDamageType = (int)playerData.droneDamageType;
    }


    public int GetHealthPoints()
    {
        return playerStats.health;
    }

    public int GetArmorPoints()
    {
        return playerStats.armor;
    }

    public int GetSpeedPoints()
    {
        return playerStats.speed;
    }

    public int GetCritChancePoints()
    {
        return playerStats.critChance;
    }

    public int GetDroneDamage()
    {
        return playerStats.droneDamage;
    }

    public int GetDroneROF()
    {
        return playerStats.droneROF;
    }

    public int GetDroneDamageType()
    {
        return playerStats.droneDamageType;
    }


    public int GetHealthValue()
    {
        int multiplier = 10 * playerStats.health;
        return 100 + multiplier;
    }

    public float GetArmorValue()
    {
        float multiplier = 0.5f * playerStats.armor;
        return 0 + multiplier;

    }

    public float GetSpeedValue()
    {
        float multiplier = 0.25f * playerStats.speed;
        return 3 + multiplier;
    }

    public float GetCritChanceValue()
    {
        float multiplier = 0.1f * playerStats.critChance;
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

    public float GetDroneROFValue()
    {
        float multiplier = 0.1f * playerStats.droneROF;
        return 2 - multiplier;
    }


    public void UpdatPlayerStats()
    {
        PlayerDataManager.Instance.SetPlayerStats(GetHealthPoints(), GetSpeedValue(), GetCritChanceValue(), playerStats.armor, playerStats.droneDamage, playerStats.droneROF);
        
    }



}


[System.Serializable]
public class PlayerValues
{
    public int health, armor, speed, critChance;
    public int droneDamage, droneROF, droneDamageType;
}
