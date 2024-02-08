using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsView : MonoBehaviour
{
    public StatsPresenter presenter;


    public Text HealthValueText, ArmorValueText, SpeedValueText, CritValueText;

    public Text DroneDamageText, DroneROFText, DroneDamageTypeText;

    public Text HealthCostText, ArmorCostText, SpeedCostText, CritCostText, DroneDamageCostText, DroneROFCostText, DroneTypeCostText;

    public Text coinText;


    public void UpdatePlayerStatsUI()
    {
        HealthValueText.text = presenter.model.GetHealthValue().ToString();
        ArmorValueText.text = presenter.model.GetArmorValue().ToString();
        SpeedValueText.text = presenter.model.GetSpeedValue().ToString();
        CritValueText.text = presenter.model.GetCritChanceValue().ToString();

        DroneDamageText.text = presenter.model.GetDroneDamageValue().ToString();
        DroneROFText.text = presenter.model.GetDroneROFValue().ToString();
        DroneDamageTypeText.text = GetDamageTypeValue(presenter.model.GetDroneDamageType());

        HealthCostText.text = presenter.model.GetStatCost(presenter.model.GetHealthPoints()).ToString();
        ArmorCostText.text = presenter.model.GetStatCost(presenter.model.GetArmorPoints()).ToString();
        SpeedCostText.text = presenter.model.GetStatCost(presenter.model.GetSpeedPoints()).ToString();
        CritCostText.text = presenter.model.GetStatCost(presenter.model.GetCritChancePoints()).ToString();
        DroneDamageCostText.text = presenter.model.GetStatCost(presenter.model.GetDroneDamage()).ToString();
        DroneROFCostText.text = presenter.model.GetStatCost(presenter.model.GetDroneROF()).ToString();
        DroneTypeCostText.text = presenter.model.GetStatCost(presenter.model.GetDroneDamageType()).ToString();
        CheckMaxUI();

        coinText.text = PlayerDataManager.Instance.GetPlayerCoins().ToString();
    }


    void CheckMaxUI()
    {


        HealthCostText.gameObject.SetActive(presenter.model.GetHealthPoints() < presenter.model.playerStats.statMaxValue);
        ArmorCostText.gameObject.SetActive(presenter.model.GetArmorPoints() < presenter.model.playerStats.statMaxValue);
        SpeedCostText.gameObject.SetActive(presenter.model.GetSpeedPoints() < presenter.model.playerStats.statMaxValue);
        CritCostText.gameObject.SetActive(presenter.model.GetCritChancePoints() < presenter.model.playerStats.statMaxValue);
        DroneDamageCostText.gameObject.SetActive(presenter.model.GetDroneDamage() < presenter.model.playerStats.statMaxValue);
        DroneROFCostText.gameObject.SetActive(presenter.model.GetDroneROF() < presenter.model.playerStats.statMaxValue);
        DroneTypeCostText.gameObject.SetActive(presenter.model.GetDroneDamageType() < presenter.model.playerStats.droneDamageMaxValue);

        // SpeedValueText.text = presenter.model.GetSpeedValue().ToString();
        //  CritValueText.text

    }





    string GetDamageTypeValue(int i)
    {
        switch(i)
        {
            case 0:
                return "SLOW";

            case 1:
                return "BURN";

            case 2:
                return "STUN";
        }
        return "";
    }

}
