using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHelper : MonoBehaviour
{
    [SerializeField]private DroneMovement drone;
    private Vector3 initialPosition;

    private void Start()
    {
        AudioManager.Instance.PlayMusic("BG");
    }


    public void GoToNextSpawn()
    {
        Transform newSpawn = LevelGenerator.Instance.GetActiveLevel();
        
        transform.SetLocalPositionAndRotation(newSpawn.position, Quaternion.identity);
       

        drone.ResetPositionToPlayer(newSpawn.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EXP" && gameObject.tag == "Player")
        {
            //GameUIManager.Instance.UpdateExp();
            AudioManager.Instance.PlaySFX("Coin");
            PlayerDataManager.Instance.AddPlayerCoins();
            GameUIManager.Instance.UpdateCoinText(PlayerDataManager.Instance.playerCoins);
            Destroy(other.gameObject);
        }

        if(other.tag == "PU" && gameObject.tag == "Player")
        {
            Debug.Log("PU TRIGGER");
            CheckPowerupTrigger(other.gameObject);
        }
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Resource")
        {
            collision.gameObject.GetComponent<LootDrop>().GetLoot();
        }
    }


    void CheckPowerupTrigger(GameObject other)
    {

        int ID = other.GetComponent<PowerupTrigger>().powerupID;
        GameObject.FindObjectOfType<SponsorPresenter>().SetupSponsorUI(ID);
        Destroy(other);
        switch(ID)
        {
            case 0:
                break;

            case 1:
           //     GetComponent<PlayerInventory>().AddHealth();
                break;

            case 2:
              //  GetComponent<PlayerInventory>().AddSpeed();
                break;
            case 3:
            //    GetComponent<PlayerInventory>().EnableShield();
                break;
        }
    }
}
