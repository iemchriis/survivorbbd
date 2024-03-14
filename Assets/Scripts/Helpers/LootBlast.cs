using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBlast : MonoBehaviour
{
    public GameObject loot;
    public int numOfLoots;
    public float burstDelay = 0.15f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for(int i = 0; i < numOfLoots; i++)
        {
            GameObject tempLoot = Instantiate(loot);
            tempLoot.transform.position = transform.position;
            yield return new WaitForSeconds(burstDelay);
        }
    }


}
