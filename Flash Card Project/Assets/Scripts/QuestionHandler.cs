using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class QuestionHandler : MonoBehaviour
{
    public int totalQuestions;
    public int numCorrect;
    public TMP_Text timer;
    public TMP_Text otherText;
    public TMP_Text result;
    
    public QuestionGenerator qG;
    public UI ui;
    
    public void startQuestion()
    {
        totalQuestions = 0;
        numCorrect = 0;
        initializeQuestion();
    }

    public void quit()
    {
        Application.Quit();
    }


    public void buttonAClicked()
    {
        checkAnswer(1);
    }
    
    public void buttonBClicked()
    {
        checkAnswer(2);
    }
    
    public void buttonCClicked()
    {
        checkAnswer(3);
    }

    private void checkAnswer(int bClicked)
    {
        if (qG.getCorrectAnswer() == bClicked)
        {
            numCorrect++;
        }
        totalQuestions++;
        initializeQuestion();
    }

    private void initializeQuestion()
    {
        StopAllCoroutines();
        if(totalQuestions < 3)
        {
            qG.GenerateQuestion();
            StartCoroutine(countdown());
        }
        else
        {
            endGame();
        }
    }
    
    private IEnumerator countdown()
    {
        otherText.text = "question ends";
        int time = 10;
        while (time > 0)
        {
            timer.text = time.ToString();
            yield return new WaitForSeconds(1);
            time--;
        }

        totalQuestions++;
        initializeQuestion();
    }

    private void endGame()
    {
        result.text = numCorrect.ToString() + "/" + totalQuestions.ToString();
        ui.HidesGame();
        ui.ShowsGameResults();
    }
}
