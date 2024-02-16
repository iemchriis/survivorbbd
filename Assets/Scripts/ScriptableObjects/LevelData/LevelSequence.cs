using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "LevelSequence", menuName = "Level/Sequence")]
public class LevelSequence : ScriptableObject
{
    
    public List<LevelCollection> Sequence = new List<LevelCollection>();
}
