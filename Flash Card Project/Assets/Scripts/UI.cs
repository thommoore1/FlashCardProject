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
