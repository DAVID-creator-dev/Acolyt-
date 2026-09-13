using UnityEngine;
using TMPro; 

public class LetterInputField : MonoBehaviour
{
    public TMP_InputField inputField; 
    
    void Start()
    {
        inputField.onValidateInput = Validate; 
    }

    char Validate(string input, int charIndex, char addedChar) => char.IsLetter(addedChar) ? addedChar : '\0'; 
}
