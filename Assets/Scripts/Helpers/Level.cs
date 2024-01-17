using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private bool isLevelEnded;
    public GameObject[] Door;

    private void Start()
    {
        GameManager.Instance.SetCurrentLevel(this);
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
     //   Door.SetActive(true);
    }

    public bool LevelEnded()
    {
        return isLevelEnded;
    }
}
