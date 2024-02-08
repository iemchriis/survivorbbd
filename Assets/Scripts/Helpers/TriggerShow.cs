using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShow : MonoBehaviour
{
    public GameObject Canvas;
    private void OnTriggerEnter(Collider other)
    {

        Canvas.SetActive(true);
     
    }
}
