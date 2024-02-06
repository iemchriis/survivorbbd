using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPresenter : MonoBehaviour
{
    public StatsUpgradeModel model;
    public StatsView view;



    private void Start()
    {
        view.UpdatePlayerStatsUI();
    }


    public void UpdateStat(int statIndex)
    {
        int playerCoins = PlayerDataManager.Instance.GetPlayerCoins();


        switch(statIndex)
        {
            case 0:
                if (playerCoins >= model.GetStatCost(model.playerStats.health))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.health));
                    model.playerStats.health += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;
            case 1:
                if (playerCoins >= model.GetStatCost(model.playerStats.armor))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.armor));
                    model.playerStats.armor += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;
            case 2:
                if (playerCoins >= model.GetStatCost(model.playerStats.speed))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.speed));
                    model.playerStats.speed += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;
            case 3:
                if (playerCoins >= model.GetStatCost(model.playerStats.critChance))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.critChance));
                    model.playerStats.critChance += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;

            case 4:
                if (playerCoins >= model.GetStatCost(model.playerStats.droneDamage))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.droneDamage));
                    model.playerStats.droneDamage += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;

            case 5:
                if (playerCoins >= model.GetStatCost(model.playerStats.droneROF))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.droneROF));
                    model.playerStats.droneROF += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;

            case 6:
                if (playerCoins >= model.GetStatCost(model.playerStats.droneDamageType))
                {
                    PlayerDataManager.Instance.DeductCoins(model.GetStatCost(model.playerStats.droneDamageType));
                    model.playerStats.droneDamageType += 1;
                    view.UpdatePlayerStatsUI();
                }
                break;

        }
        model.UpdatPlayerStats();


    }
}
