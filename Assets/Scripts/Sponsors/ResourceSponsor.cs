using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSponsor : SponsorBase
{
    public override void Upgrade(int i)
    {
        switch (i)
        {
            case 0:
                AddGems();
                break;

            case 1:
                UpgradeHealth();
                break;

            case 2:
              //  UpgradeDroneRate();
                break;

        }

    }



    void AddGems()
    {
        PlayerDataManager.Instance.AddPlayerCoins();
    }


    void UpgradeHealth()
    {
        GameObject.FindObjectOfType<PlayerInventory>().AddHealth();
    }


    void UpgradeDroneRate()
    {
       // GameObject.FindObjectOfType<DroneWeapon>().UpgradeDroneROF();
    }
}
