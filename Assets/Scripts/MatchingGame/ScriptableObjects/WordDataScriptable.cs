using UnityEngine;
using System.Collections.Generic; 

[CreateAssetMenu(fileName = "Word_Data", menuName = "Game/WorldData", order = 1)]
public class WordDataScriptable : ScriptableObject
{
    public List<string> syllables; 
    public string word;
    public Sprite image;
}
