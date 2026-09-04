using UnityEngine;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private MatchingGameManager matchingGameManager;
    [SerializeField] private MatchingExercise matchingExercise; 
    [SerializeField] private GameObject[] panelsToHide;
    [SerializeField] private GameObject[] panelsToShow;

    public void Generate()
    {
        if (!matchingGameManager.HasSelectedSyllables())
        {
            ErrorMessage.Show("Tu as oublié de sélectionner des syllabes", 1.0f);
            return;
        }

        matchingExercise.GeneratePdf();    

        foreach(GameObject panel in panelsToHide)
            panel.SetActive(false);

        foreach(GameObject panel in panelsToShow)
            panel.SetActive(true);
    }
}
