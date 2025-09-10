using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
    public int totalQuestions;
    public int numCorrect;
    
    public QuestionGenerator qG;
    
    public void startQuestion()
    {
        initializeQuestion();
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
        if (totalQuestions < 3)
        {
            initializeQuestion();
        }
        else
        {
            //transition to end screen here
        }
    }

    private void initializeQuestion()
    {
        qG.GenerateQuestion();
    }
}
