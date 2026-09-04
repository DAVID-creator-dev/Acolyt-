using UnityEngine;
using System.Collections.Generic;

public class MatchingGameManager : MonoBehaviour
{
    private List<WordDataScriptable> exerciseWords = new List<WordDataScriptable>();
    private List<string> exerciseSyllables = new List<string>();

    public IReadOnlyList<WordDataScriptable> GetExerciseWords() => exerciseWords;
    public IReadOnlyList<string> GetExerciseSyllables() => exerciseSyllables;

    public bool HasSelectedWords() => exerciseWords.Count > 0; 
    public bool HasSelectedSyllables() => exerciseSyllables.Count > 0;

    public void AddToExercise(WordDataScriptable wordDataScriptable)
    {
        exerciseWords.Add(wordDataScriptable);
    }

    public void RemoveFromExercise(WordDataScriptable wordDataScriptable)
    {
        exerciseWords.Remove(wordDataScriptable);
    }

    public void AddSyllable(string syllable)
    {
        exerciseSyllables.Add(syllable);
    }

    public void RemoveSyllable(string syllable)
    {
        exerciseSyllables.Remove(syllable);
    }
}
