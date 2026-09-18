using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic;
using System.Linq;
using TMPro;
using System;

public class ScrollViewSentences : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] private GameObject buttonPrefab;
    [HideInInspector] public List<LessonScriptable> lessonsScriptable = new List<LessonScriptable>();
    [SerializeField] private WriteSentencesManager writeSentencesManager;  

    public void Start()
    {
        lessonsScriptable = Resources.LoadAll<LessonScriptable>("ScriptableObjects").ToList();
        if(lessonsScriptable.Count <= 0)
        {
            Debug.Log("No wordDataScriptables found!");
            return;
        }

        foreach(LessonScriptable lessonScriptable in lessonsScriptable)
            foreach(Sentence sentence in lessonScriptable.sentences)
                AddButton(sentence);
    }

    void AddButton(Sentence sentence)
    {
        GameObject newButtonObj = Instantiate(buttonPrefab, scrollView.content);
        newButtonObj.GetComponentInChildren<TMP_Text>().text = sentence.sentence;

        SentenceButton sentenceButton = newButtonObj.GetComponent<SentenceButton>(); 
        sentenceButton.sentence = sentence; 
        sentenceButton.writeSentencesManager = writeSentencesManager; 
    }
}
