using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AdjustMusic(float i)
    {
        AudioManager.Instance.Music(i);
    }


    public void AdjustSFX(float i)
    {
        AudioManager.Instance.SFX(i);
    }
}
