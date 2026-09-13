using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private List<WordDataScriptable> exerciseWords = new List<WordDataScriptable>(); 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public bool HasSelectedWords() => exerciseWords.Count > 0; 

    public IReadOnlyList<WordDataScriptable> GetExerciseWords() => exerciseWords; 

    public void AddToExercise(WordDataScriptable wordDataScriptable) => exerciseWords.Add(wordDataScriptable); 

    public void RemoveFromExercise(WordDataScriptable wordDataScriptable) => exerciseWords.Remove(wordDataScriptable); 
}