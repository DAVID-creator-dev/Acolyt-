using UnityEngine;
using UnityEngine.UI;

public class SyllableButton : MonoBehaviour
{
    [HideInInspector] public string syllable;
    [HideInInspector] public MatchingGameManager matchingGameManager;
    

    [SerializeField] private Color selectedColor = Color.gray;

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
            matchingGameManager.RemoveSyllable(syllable);
        else
            matchingGameManager.AddSyllable(syllable);

        isAdded = !isAdded;
        buttonImage.color = isAdded ? selectedColor : normalColor;
    }
}
