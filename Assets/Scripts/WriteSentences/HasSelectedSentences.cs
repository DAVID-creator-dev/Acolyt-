using UnityEngine;

public class HasSelectedSentences : ConditionCheck
{
    [SerializeField] private WriteSentencesManager writeSentencesManager;

    public override bool IsMet() => writeSentencesManager.HasSelectedSentences();
}
