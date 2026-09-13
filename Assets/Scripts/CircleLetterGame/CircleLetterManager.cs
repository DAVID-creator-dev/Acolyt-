using UnityEngine;

public class CircleLetterManager : MonoBehaviour
{
    private string lettersToCircle;

    public string GetExerciseLetters() => lettersToCircle;

    public bool HasEnteredLetters() => !string.IsNullOrEmpty(lettersToCircle);

    public void SetLetters(string letters) => lettersToCircle = letters;
}
