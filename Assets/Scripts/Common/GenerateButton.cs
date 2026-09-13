using UnityEngine;
using UnityEngine.Events;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private ConditionCheck[] conditions;
    [SerializeField] private UnityEvent onGenerate;
    [SerializeField] private GameObject[] panelsToHide;
    [SerializeField] private GameObject[] panelsToShow;

    public void Generate()
    {
        foreach (ConditionCheck condition in conditions)
        {
            if (!condition.IsMet())
            {
                condition.ShowError();
                return;
            }
        }

        onGenerate.Invoke();

        foreach (GameObject panel in panelsToHide)
            panel.SetActive(false);

        foreach (GameObject panel in panelsToShow)
            panel.SetActive(true);
    }
}
