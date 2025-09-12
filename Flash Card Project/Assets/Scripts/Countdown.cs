/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 1
 *
 * 2)
 * This file is used to control the initial start game countdown and to begin the game
 */

using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    /*
     * Question Handler object, used for handling the questions given by game
     */
    public QuestionHandler qHandler;
    /*
     * Text used for displaying the text that displays for the countdown number (or when it says Go!)
     */
    public TMP_Text countdownText;
    /*
     * Used for text that displays game state
     */
    public TMP_Text otherText;
    /*
     * UI object for changing UI
     */
    public UI ui;
    
    /*
     * a. StartButton()
     * b. does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void startButton()
    {
        StopAllCoroutines();
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
        ui.HidesSG();
        ui.HidesGameResults();
        ui.ShowsGame();
        otherText.text = "game starts";
        int time = 5;
        while (time > 0)
        {
            countdownText.text = time.ToString();
            yield return new WaitForSeconds(1);
            time--;
        }
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1);
        qHandler.startQuestion();
    }
}
