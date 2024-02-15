using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelCollection", menuName = "Level/Collection")]
public class LevelCollection : ScriptableObject
{
    public List<Level> Levels = new List<Level>();


    public GameObject GetLevelFromList()
    {
        int rand = Random.Range(0, Levels.Count);

        for (int i = 0; i < Levels.Count; i++)
        {
            if(i == rand)
            {
                return Levels[i].gameObject;
            }
        }
        return null;    
    }

}
