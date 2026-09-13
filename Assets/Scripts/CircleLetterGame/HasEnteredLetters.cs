using UnityEngine;

public class HasEnteredLetters : ConditionCheck
{
    [SerializeField] private CircleLetterManager circleLetterManager;

    public override bool IsMet() => circleLetterManager.HasEnteredLetters();
}
