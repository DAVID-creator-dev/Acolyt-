using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Lesson_Data", menuName = "Game/LessonData", order = 1)]
public class LessonScriptable : ScriptableObject
{
    public List<Sentence> sentences;
}

[System.Serializable]
public class Sentence
{
    public string sentence;
    public List<Word> words;
}

[System.Serializable]
public class Word
{
    public List<string> syllables;
}
