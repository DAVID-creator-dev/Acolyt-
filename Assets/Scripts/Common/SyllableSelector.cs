using UnityEngine;

public abstract class SyllableSelector : MonoBehaviour
{
    public abstract void AddSyllable(string syllable);
    public abstract void RemoveSyllable(string syllable);
    public abstract void ClearSyllables(); 
}
