using UnityEngine;

public class HasSelectedSyllables : ConditionCheck
{
    [SerializeField] private MatchingGameManager matchingGameManager;

    public override bool IsMet() => matchingGameManager.HasSelectedSyllables();
}
