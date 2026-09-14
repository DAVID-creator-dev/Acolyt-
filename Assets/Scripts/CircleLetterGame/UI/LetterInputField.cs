using UnityEngine;
using TMPro; 

public class LetterInputField : MonoBehaviour
{
    public TMP_InputField inputField;

    [SerializeField] private CircleLettersManager circleLetterManager;

    void Start()
    {
        inputField.onValidateInput = Validate;
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    char Validate(string input, int charIndex, char addedChar) => char.IsLetter(addedChar) ? addedChar : '\0';

    void OnValueChanged(string letters) => circleLetterManager.SetLetters(letters);
}
