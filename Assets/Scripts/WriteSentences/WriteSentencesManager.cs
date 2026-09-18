using UnityEngine;
using System.Collections.Generic;

public class WriteSentencesManager : MonoBehaviour
{
    private List<Sentence> exerciseSentences = new List<Sentence>();
    public IReadOnlyList<Sentence> GetExerciseSentenes() => exerciseSentences;
    public bool HasSelectedSentences() => exerciseSentences.Count > 0;

    public void AddSentence(Sentence sentence) => exerciseSentences.Add(sentence);
    public void RemoveSentence(Sentence sentence) => exerciseSentences.Remove(sentence);
}
