using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup startScreenGroup;
    public CanvasGroup gameScreenGroup;
    public CanvasGroup gameResultsGroup;

    public void ShowsSG()
    {
        CanvasGroupDisplayer.Show(startScreenGroup);
    }
    
    public void ShowsGame()
    {
        CanvasGroupDisplayer.Show(gameScreenGroup);
    }

    public void ShowsGameResults()
    {
        CanvasGroupDisplayer.Show(gameResultsGroup);
    }

    public void HidesSG()
    {
        CanvasGroupDisplayer.Hide(startScreenGroup);
    }
    

    public void HidesGame()
    {
        CanvasGroupDisplayer.Hide(gameScreenGroup);
    }

    public void HidesGameResults()
    {
        CanvasGroupDisplayer.Hide(gameResultsGroup);
    }
}
