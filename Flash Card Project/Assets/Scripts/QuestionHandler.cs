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

using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEditor;

public class QuestionHandler : MonoBehaviour
{
    /*
     * Audio clip for correct answer and incorrect answer
     */
    public AudioClip correct;
    public AudioClip wrong;
    /*
     * Audio CLips for background music
     */
    public AudioClip lobbyTrack;
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

    private int timeSpent = 0;
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
     * Used to effect UI
     */
    public UI ui;
    
    //amount of questions to answer
    public int amountQuestions = 3;
    
    //which type of quiz is it, 1-a,2-s,3-m,4-d,5-all
    public int quizType;
    
    /*
     * a. startQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void Start()
    {
        SoundManager.Instance.playBackGroundTrack(lobbyTrack);
    }

    public void startQuestion()
    {
        totalQuestions = 0;
        numCorrect = 0;
        initializeQuiz();
    }

    //sets the quiz type
    public void SetQuizType(int qT)
    {
        quizType = qT;
    }
    
    /*
     * a. quit()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    /*
     * a. buttonClicked()
     * b. Does not return a value
     * c. Takes in value
     * d. No exceptions thrown
     */
    public void buttonClicked(int button)
    {
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
        AchievementEvents.OnRoundStart?.Invoke(new AchievementEvents.OnRoundStartArgs());
        StopAllCoroutines();
        qG.reset();
        timeSpent = 0;
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
            SoundManager.Instance.playButtonSFX(correct);
            numCorrect++;
            AchievementEvents.OnQuestionAnswered?.Invoke(new AchievementEvents.OnQuestionAnsweredArgs()
            {
                AnsweredCorrectly =  true,
                TimeRemaining =  currentTime,
            });
        }
        else
        {
            SoundManager.Instance.playButtonSFX(wrong);
        }
        timeSpent = timeSpent + (10 - currentTime);
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
        qG.GenerateQuiz(amountQuestions, quizType);
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

        timeSpent = timeSpent + 10;
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
        SoundManager.Instance.switchBackGroundTrackWithFade(lobbyTrack);
        result.text = numCorrect.ToString() + "/" + totalQuestions.ToString();
        ui.HidesGame();
        ui.ShowsGameResults();
        AchievementEvents.OnRoundEnded?.Invoke(new AchievementEvents.OnRoundEndedArgs
        {
            QuizType = quizType,
            NumQuestionsAnswered = totalQuestions,
            NumCorrectQuestions = numCorrect,
            TotalTimeTaken = timeSpent,
        });
        
    }
}
