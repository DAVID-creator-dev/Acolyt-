using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 
using System.Linq;
using TMPro; 

public class WordsScrollView : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] private GameObject buttonPrefab;
    [HideInInspector] public List<WordDataScriptable> wordDataScriptables = new List<WordDataScriptable>();

    void Start()
    {
        wordDataScriptables = Resources.LoadAll<WordDataScriptable>("ScriptableObjects").ToList();
        if(wordDataScriptables.Count < 0)
        {
            Debug.Log("No wordDataScriptables found!"); 
            return;
        }

        foreach(WordDataScriptable wordDataScriptable in wordDataScriptables)
            AddButton(wordDataScriptable);
    }

    void AddButton(WordDataScriptable wordDataScriptable)
    {
        GameObject newButtonObj = Instantiate(buttonPrefab, scrollView.content);
        newButtonObj.GetComponentInChildren<TMP_Text>().text = wordDataScriptable.word;
        newButtonObj.transform.Find("IconArea/Icon").GetComponent<Image>().sprite = wordDataScriptable.image;

        WordButton wordButton = newButtonObj.GetComponent<WordButton>();
        wordButton.wordDataScriptable = wordDataScriptable;
    }
}
