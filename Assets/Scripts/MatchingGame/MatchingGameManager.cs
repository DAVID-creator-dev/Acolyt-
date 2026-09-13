using UnityEngine;
using System.Collections.Generic;

public class MatchingGameManager : MonoBehaviour
{
    private List<string> exerciseSyllables = new List<string>();
    public IReadOnlyList<string> GetExerciseSyllables() => exerciseSyllables;

    public bool HasSelectedSyllables() => exerciseSyllables.Count > 0;

    public void AddSyllable(string syllable)
    {
        exerciseSyllables.Add(syllable);
    }

    public void RemoveSyllable(string syllable)
    {
        exerciseSyllables.Remove(syllable);
    }
}
