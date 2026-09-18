using UnityEngine;
using UnityEngine.UI;

public class SentenceButton : MonoBehaviour
{
    [HideInInspector] public Sentence sentence;
    [SerializeField] private Color selectedColor = Color.gray;
    [HideInInspector] public WriteSentencesManager writeSentencesManager;

    private bool isAdded;
    private Image buttonImage;
    private Color normalColor;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        normalColor = buttonImage.color;

        GetComponent<Button>().onClick.AddListener(ToggleExercise);
    }

    void ToggleExercise()
    {
        if (isAdded)
            writeSentencesManager.RemoveSentence(sentence);
        else
            writeSentencesManager.AddSentence(sentence);

        isAdded = !isAdded;
        buttonImage.color = isAdded ? selectedColor : normalColor;
    }
}
