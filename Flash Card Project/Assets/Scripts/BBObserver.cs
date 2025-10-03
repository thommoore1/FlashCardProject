using UnityEngine;

public class BBObserver : MonoBehaviour
{
    //Question Handler is my class that handles question answering
    //in the section of Question Handler where it checks if
    //answer is correct i invoke a static event called answer selected
    //which passes in the bool of if it was correct and an int of how much time was left
    
    //put this class on an empty object or observer object
    private void OnEnable()//subscribes to event
    {
        QuestionHandler.AnswerSelected += HandleAnswerSelected;
    }

    private void OnDisable() //unsubscribes to event
    {
        QuestionHandler.AnswerSelected -= HandleAnswerSelected;
    }
    public void HandleAnswerSelected(bool isCorrect, float timeLeft)
    {
        if (isCorrect && timeLeft <= 1)
        {
            Debug.Log("Buzzer Beater Completed");// prints achievment completion
            QuestionHandler.AnswerSelected -= HandleAnswerSelected;//unsubscribes to event
        }
       
    }
}
