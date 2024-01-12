using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHelper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EXP" && gameObject.tag == "Player")
        {
            GameUIManager.Instance.UpdateExp();
            Destroy(other.gameObject);
        }
       
    }
}
