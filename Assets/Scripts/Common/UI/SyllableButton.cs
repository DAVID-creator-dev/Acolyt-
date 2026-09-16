using UnityEngine;
using UnityEngine.UI;

public class SyllableButton : MonoBehaviour
{
    [HideInInspector] public string syllable;
    [HideInInspector] public SyllableSelector syllableSelector;
    

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
            syllableSelector.RemoveSyllable(syllable);
        else
            syllableSelector.AddSyllable(syllable);

        isAdded = !isAdded;
        buttonImage.color = isAdded ? selectedColor : normalColor;
    }
}
