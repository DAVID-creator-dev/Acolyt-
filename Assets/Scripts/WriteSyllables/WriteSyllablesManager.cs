using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

public class WriteSyllablesManager : SyllableSelector
{
    private List<string> exerciseSyllables = new List<string>();
    public IReadOnlyList<string> GetExerciseSyllables() => exerciseSyllables;

    public bool HasSelectedSyllables() => exerciseSyllables.Count > 0;

    public override void AddSyllable(string syllable) => exerciseSyllables.Add(syllable);
    public override void RemoveSyllable(string syllable) => exerciseSyllables.Remove(syllable);
    public override void ClearSyllables() => exerciseSyllables.Clear(); 
}
