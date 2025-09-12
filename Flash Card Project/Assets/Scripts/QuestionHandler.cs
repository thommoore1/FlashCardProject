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
    public QuestionGenerator qG;
    /*
     * Used to effect AI
     */
    public UI ui;
    
    /*
     * a. startQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void startQuestion()
    {
        totalQuestions = 0;
        numCorrect = 0;
        initializeQuestion();
    }

    /*
     * a. quit()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void quit()
    {
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }


    /*
     * a. buttonAClicked()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void buttonAClicked()
    {
        audioData.Play();
        checkAnswer(1);
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
     * a. buttonBClicked()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void buttonBClicked()
    {
        audioData.Play();
        checkAnswer(2);
    }
    
    /*
     * a. buttonCClicked()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void buttonCClicked()
    {
        audioData.Play();
        checkAnswer(3);
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
        initializeQuestion();
    }
    
    /*
     * a. initializeQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
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
    
    /*
     * a. countdown()
     * b. yield return new WaitForSeconds()
     * c. Does not take in value
     * d. No exceptions thrown
     */
    
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
    
    /*
     * a. endGame()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    private void endGame()
    {
        result.text = numCorrect.ToString() + "/" + totalQuestions.ToString();
        ui.HidesGame();
        ui.ShowsGameResults();
    }
}
