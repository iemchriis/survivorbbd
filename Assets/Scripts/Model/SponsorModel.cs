using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorModel : MonoBehaviour
{

    public List<SponsorList> sponsors = new List<SponsorList>();
    int chosenSponsor;


    public void UpgradeSponsor(int i)
    {
        sponsors[chosenSponsor].sponsor.Upgrade(i);
    }

    public SponsorList GetSponsor()
    {
        return sponsors[chosenSponsor];
    }

    public void SetSponsor(int i)
    {
        chosenSponsor = i;
    }



}

[System.Serializable]
public class SponsorList
{
    public SponsorBase sponsor;
    public SponsorRarity sponsorRarity;
    public string[] sponsorDescription;
    public string sponsorName;
}

public enum SponsorRarity
{
    COMMON,
    RARE,
    EPIC

}
