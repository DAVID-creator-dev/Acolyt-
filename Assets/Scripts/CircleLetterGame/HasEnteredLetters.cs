using UnityEngine;

public class HasEnteredLetters : ConditionCheck
{
    [SerializeField] private CircleLettersManager circleLetterManager;

    public override bool IsMet() => circleLetterManager.HasEnteredLetters();
}
