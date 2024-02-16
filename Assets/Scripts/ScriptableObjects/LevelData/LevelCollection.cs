using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelCollection", menuName = "Level/Collection")]
public class LevelCollection : ScriptableObject
{
    public List<Level> Levels = new List<Level>();


    public Level GetCurrentLevel(int index)
    {
        return Levels[index];
    }

    public Level GetLevelFromList()
    {
        int rand = Random.Range(0, Levels.Count);
        Debug.Log(rand);
        
        return Levels[rand];
    }

}
