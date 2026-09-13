using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SyllablesScrollView : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private MatchingGameManager matchingGameManager;

    public void Populate()
    {
        foreach (Transform child in scrollView.content)
            Destroy(child.gameObject);

        foreach (WordDataScriptable wordDataScriptable in GameManager.Instance.GetExerciseWords())
            AddWordRow(wordDataScriptable);
    }

    void AddWordRow(WordDataScriptable wordDataScriptable)
    {
        GameObject row = new GameObject(wordDataScriptable.word, typeof(RectTransform));
        row.transform.SetParent(scrollView.content, false);

        HorizontalLayoutGroup layoutGroup = row.AddComponent<HorizontalLayoutGroup>();
        layoutGroup.spacing = 10;
        layoutGroup.childAlignment = TextAnchor.MiddleLeft;
        layoutGroup.childControlWidth = false;
        layoutGroup.childControlHeight = false;
        layoutGroup.childForceExpandWidth = false;
        layoutGroup.childForceExpandHeight = false;

        foreach (string syllable in wordDataScriptable.syllables)
            AddSyllableButton(row.transform, syllable);

        AddImage(row.transform, wordDataScriptable.image);
    }

    void AddSyllableButton(Transform parent, string syllable)
    {
        GameObject newButtonObj = Instantiate(buttonPrefab, parent);
        newButtonObj.GetComponentInChildren<TMP_Text>().text = syllable;

        SyllableButton syllableButton = newButtonObj.GetComponent<SyllableButton>();
        syllableButton.syllable = syllable;
        syllableButton.matchingGameManager = matchingGameManager;
    }

    void AddImage(Transform parent, Sprite sprite)
    {
        GameObject imageObj = new GameObject("Image", typeof(RectTransform), typeof(Image));
        imageObj.transform.SetParent(parent, false);

        Image image = imageObj.GetComponent<Image>();
        image.sprite = sprite;
        image.rectTransform.sizeDelta = new Vector2(300, 300);
    }
}
