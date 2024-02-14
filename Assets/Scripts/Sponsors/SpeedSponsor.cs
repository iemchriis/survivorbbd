using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSponsor : SponsorBase
{



    public override void Upgrade(int i)
    {
        switch (i)
        {
            case 0:
                UpgradeSpeed();
                break;

            case 1:
                UpgradeFireRate();
                break;

            case 2:
                UpgradeDroneRate();
                break;

        }

    }



    void UpgradeSpeed()
    {
        GameObject.FindObjectOfType<PlayerMovement>().moveSpeed += 0.2f;
    }


    void UpgradeFireRate()
    {
        GameObject.FindObjectOfType<WeaponHolder>().UpgradeWeaponROF();
    }


    void UpgradeDroneRate()
    {
        GameObject.FindObjectOfType<DroneWeapon>().UpgradeDroneROF();
    }
}
