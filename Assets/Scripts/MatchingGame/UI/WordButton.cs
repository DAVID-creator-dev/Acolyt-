using UnityEngine;
using UnityEngine.UI;

public class WordButton : MonoBehaviour
{
    [HideInInspector] public WordDataScriptable wordDataScriptable;
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
            matchingGameManager.RemoveFromExercise(wordDataScriptable);
        else
            matchingGameManager.AddToExercise(wordDataScriptable);

        isAdded = !isAdded;
        buttonImage.color = isAdded ? selectedColor : normalColor;
    }
}
