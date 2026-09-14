using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    private Button button; 
    [SerializeField] private ConditionCheck[] conditions;
    [SerializeField] private UnityEvent onGenerate;
    [SerializeField] private GameObject[] panelsToHide;
    [SerializeField] private GameObject[] panelsToShow;

    void Start()
    {
        button = GetComponent<Button>();
        if (!button)
        {
            Debug.Log("No button found"); 
            return; 
        }

        button.onClick.AddListener(Generate); 
    }

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
