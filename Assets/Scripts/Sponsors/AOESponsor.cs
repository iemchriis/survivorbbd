using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESponsor : SponsorBase
{
    public override void Upgrade(int i)
    {
        switch (i)
        {
            case 0:
                UpgradeBomb();
                break;

            case 1:
                LandMine();
                break;

            case 2:
                Poison();
                break;

        }

    }



    void UpgradeBomb()
    {
        GameObject.FindObjectOfType<PlayerBomb>().canFire = true;
    }


    void LandMine()
    {
        GameObject.FindObjectOfType<PlayerLandmine>().canFire = true;
    }


    void Poison()
    {
        GameObject.FindObjectOfType<PlayerPoisonBomb>().canFire = true;
    }
}
