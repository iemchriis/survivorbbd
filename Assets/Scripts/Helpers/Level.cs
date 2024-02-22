using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private bool isLevelEnded;
    public List<int> randomNumber = new List<int>();
    public GameObject[] Door;

    public Transform playerSpawn;


    private void Start()
    {
        GameManager.Instance.SetCurrentLevel(this);
        GenerateRandomList();
    }


    int GetRandomNumber()
    {
        int c = Random.Range(0, Door.Length);

        while(randomNumber.Contains(c))
        {
            c = Random.Range(0, Door.Length);
        }

        return c;
    }

    void GenerateRandomList()
    {
        for(int i = 0; i < Door.Length; i++)
        {
           randomNumber.Add(GetRandomNumber());
        }

        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].transform.GetChild(0).GetComponent<DoorTrigger>().powerupIndex = randomNumber[i];
        }

    }

    public void SetLevelEnded(bool ended)
    {
        isLevelEnded = ended;
    }


    public void NewLevel()
    {
        foreach (GameObject go in Door)
        {
            go.SetActive(true);
        }
     
    }

    public bool LevelEnded()
    {
        return isLevelEnded;
    }
}
