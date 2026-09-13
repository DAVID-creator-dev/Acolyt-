using UnityEngine;

public class HasSelectedWords : ConditionCheck
{
    [SerializeField] private GameManager gameManager;

    public override bool IsMet() => gameManager.HasSelectedWords();
}
