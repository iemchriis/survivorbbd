using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorPresenter : MonoBehaviour
{


    public SponsorModel model;
    public SponsorView view;



    public void Upgrade(int i)
    {
        model.UpgradeSponsor(i);
        view.ShowSponsorCanvas(false);
    }


    public void SetupSponsorUI(int i)
    {
        model.SetSponsor(i);
        view.SetupSponsorUI(model.GetSponsor());
    }


}
