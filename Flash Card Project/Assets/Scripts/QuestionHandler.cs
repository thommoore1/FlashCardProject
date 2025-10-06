/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 1
 *
 * 2)
 * This file is used to control the state of the current questions
 */

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class QuestionHandler : MonoBehaviour
{
    /*
     * Audio source for playing button sound
     */
    public AudioSource audioData;
    /*
     * Used to represent of number of questions that have been asked
     */
    public int totalQuestions;
    /*
     * Used to represent number of correct answers
     */
    public int numCorrect;
    /*
     * Used to display time left to answer question
     */
    public TMP_Text timer;
    //used to access current time to answer
    public int currentTime;
    //used to set time to answer
    private int initialTime = 10;
    /*
     * Used to represent game state
     */
    public TMP_Text otherText;
    /*
     * Used to represent final score
     */
    public TMP_Text result;
    
    /*
     * Used to generate questions
     */
    public QuizGenerator qG;
    /*
     * Used to effect AI
     */
    public UI ui;
    
    public int amountQuestions = 3;
    public int timeSpent = 0;
    
    /*
     * a. startQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void startQuestion()
    {
        timeSpent = 0;
        totalQuestions = 0;
        numCorrect = 0;
        initializeQuiz();
    }

    /*
     * a. quit()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void quit()
    {
        if (UnityEditor.EditorApplication.isPlaying == true) //comment this if  out before building
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }


    /*
     * a. buttonClicked()
     * b. Does not return a value
     * c. Takes in value
     * d. No exceptions thrown
     */
    public void buttonClicked(int button)
    {
        audioData.Play();
        checkAnswer(button);
    }

    /*
     * a. Reset()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void Reset()
    {
        StopAllCoroutines();
        qG.reset();
    }
    

    /*
     * a. checkAnswer()
     * b. Does not return a value
     * c. Takes in the index of the button that was clicked
     * d. No exceptions thrown
     */
    private void checkAnswer(int bClicked)
    {
        if (qG.getCorrectAnswer() == bClicked)
        {
            numCorrect++;
        }
        totalQuestions++;
        nextQuestion();
        
    }
    
    /*
     * a. initializeQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    private void nextQuestion()
    {
        timeSpent += (initialTime - currentTime);
        StopAllCoroutines();
        if(totalQuestions < amountQuestions)
        {
            qG.nextQuestion();
            StartCoroutine(countdown());
        }
        else
        {
            endGame();
        }
    }
    private void initializeQuiz()
    {
        StopAllCoroutines();
        qG.GenerateQuiz(amountQuestions);
        StartCoroutine(countdown());
        
    }
    
    /*
     * a. countdown()
     * b. yield return new WaitForSeconds()
     * c. Does not take in value
     * d. No exceptions thrown
     */
    
    private IEnumerator countdown()
    {
        otherText.text = "question ends";
        currentTime = initialTime;
        while (currentTime > 0)
        {
            timer.text = currentTime.ToString();
            yield return new WaitForSeconds(1);
            currentTime--;
        }

        totalQuestions++;
        nextQuestion();
    }
    
    /*
     * a. endGame()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    private void endGame()
    {
        AchievementEvents.OnRoundEnded?.Invoke(new AchievementEvents.OnRoundEndedArgs
        {
            NumQuestionsAnswered = totalQuestions,
            NumCorrectQuestions = numCorrect,
            TotalTimeTaken = timeSpent,
        });
        result.text = numCorrect.ToString() + "/" + totalQuestions.ToString();
        ui.HidesGame();
        ui.ShowsGameResults();
    }
}
