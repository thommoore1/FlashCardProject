/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 1
 *
 * 2)
 * This file is used to control the UI
 */

using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    /*
     * Canvas Group for the start screen
     */
    public CanvasGroup startScreenGroup;
    /*
     * Canvas Group for the game screen
     */
    public CanvasGroup gameScreenGroup;
    /*
     * Canvas Group for the results screen
     */
    public CanvasGroup gameResultsGroup;

    /*
     * buttons A B C for answering flash cards
     */
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    
    
    /*
     * a. ShowsGame()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void ShowsGame()
    {
        CanvasGroupDisplayer.Show(gameScreenGroup);
    }

    /*
     * a. stopButtons()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void stopButtons()
    {
     buttonA.interactable = false;
     buttonB.interactable = false;
     buttonC.interactable = false;
    }

    /*
     * a. StartButtons()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void startButtons()
    {
     buttonA.interactable = true;
     buttonB.interactable = true;
     buttonC.interactable = true;
    }

    /*
     * a. ShowsGameResults()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void ShowsGameResults()
    {
        CanvasGroupDisplayer.Show(gameResultsGroup);
    }
    
    /*
     * a. HidesSG()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void HidesSG()
    {
     CanvasGroupDisplayer.Hide(startScreenGroup);
    }
    
    /*
     * a. HidesGame()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void HidesGame()
    {
        CanvasGroupDisplayer.Hide(gameScreenGroup);
    }

    /*
     * a. HidesGameResults()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void HidesGameResults()
    {
        CanvasGroupDisplayer.Hide(gameResultsGroup);
    }
}
