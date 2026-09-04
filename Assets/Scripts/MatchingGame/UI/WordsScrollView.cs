using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class WordsScrollView : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private MatchingGameManager matchingGameManager;

    void Start()
    {
        foreach(WordDataScriptable wordDataScriptable in GameManager.Instance.wordDataScriptables)
            AddButton(wordDataScriptable);
    }

    void AddButton(WordDataScriptable wordDataScriptable)
    {
        GameObject newButtonObj = Instantiate(buttonPrefab, scrollView.content);
        newButtonObj.GetComponentInChildren<TMP_Text>().text = wordDataScriptable.word;
        newButtonObj.transform.Find("IconArea/Icon").GetComponent<Image>().sprite = wordDataScriptable.image;

        WordButton wordButton = newButtonObj.GetComponent<WordButton>();
        wordButton.wordDataScriptable = wordDataScriptable;
        wordButton.matchingGameManager = matchingGameManager;
    }
}
