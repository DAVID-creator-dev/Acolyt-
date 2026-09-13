using UnityEngine;
using UnityEngine.UI;

public class WordButton : MonoBehaviour
{
    [HideInInspector] public WordDataScriptable wordDataScriptable;

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
            GameManager.Instance.RemoveFromExercise(wordDataScriptable);
        else
            GameManager.Instance.AddToExercise(wordDataScriptable);

        isAdded = !isAdded;
        buttonImage.color = isAdded ? selectedColor : normalColor;
    }
}
