using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SponsorView : MonoBehaviour
{
    [SerializeField] private Text[] sponsorDescriptions;
    [SerializeField] private Text sponsorName;

    [SerializeField] private GameObject sponsorCanvas;




    public void SetupSponsorUI(SponsorList list)
    {
        ShowSponsorCanvas(true);
        sponsorName.text = list.sponsorName;
        for (int i = 0; i < sponsorDescriptions.Length; i++)
        {
            sponsorDescriptions[i].text = list.sponsorDescription[i];
        }
    }

    public void ShowSponsorCanvas(bool active)
    {
        sponsorCanvas.SetActive(active);
    }


}
