using UnityEngine;

public class NextButton : MonoBehaviour
{
    [SerializeField] private SyllablesScrollView syllablesScrollView;
    [SerializeField] private GameObject[] panelsToHide;
    [SerializeField] private GameObject[] panelsToShow;

    public void Next()
    {
        if (!GameManager.Instance.HasSelectedWords())
        {
            ErrorMessage.Show("Tu as oublié de sélectionner des mots", 1.0f);
            return;
        }

        syllablesScrollView.Populate();    

        foreach(GameObject panel in panelsToHide)
            panel.SetActive(false);

        foreach(GameObject panel in panelsToShow)
            panel.SetActive(true);
    }
}
