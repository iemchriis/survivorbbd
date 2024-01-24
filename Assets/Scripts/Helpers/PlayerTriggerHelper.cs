using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHelper : MonoBehaviour
{

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        AudioManager.Instance.PlayMusic("BG");
    }


    public void GoToInitPosition()
    {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EXP" && gameObject.tag == "Player")
        {
            GameUIManager.Instance.UpdateExp();
            Destroy(other.gameObject);
        }
        if(other.tag == "PU" && gameObject.tag == "Player")
        {
            CheckPowerupTrigger(other.gameObject);
        }
       
    }


    void CheckPowerupTrigger(GameObject other)
    {

        int ID = other.GetComponent<PowerupTrigger>().powerupID;
        Destroy(other);
        switch(ID)
        {
            case 0:
                break;

            case 1:
                GetComponent<PlayerInventory>().AddHealth();
                break;

            case 2:
                GetComponent<PlayerInventory>().AddSpeed();
                break;
            case 3:
                GetComponent<PlayerInventory>().EnableShield();
                break;
        }
    }
}
