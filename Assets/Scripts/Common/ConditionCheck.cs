using UnityEngine;

public abstract class ConditionCheck : MonoBehaviour
{
    [SerializeField] private string errorMessage;

    public abstract bool IsMet();

    public void ShowError() => ErrorMessage.Show(errorMessage, 1.0f);
}
