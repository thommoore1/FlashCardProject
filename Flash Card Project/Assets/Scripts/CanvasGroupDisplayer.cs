/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 1
 *
 * 2)
 * This file is used to control whether a canvas is displayed or not. It toggles the alpha, interactability, and raycasts on and off
 *
 */



using UnityEngine;

public static class CanvasGroupDisplayer
{   
    /*
     * a. Show()
     * b. does not return a value
     * c. Takes in a CanvasGroup object that you want to make visible and interactable
     * d. No exceptions thrown
     */
    public static void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    /*
     * a. Hide()
     * b. does not return a value
     * c. Takes in a CanvasGroup object that you want to make hidden and uninteractable
     * d. No exceptions thrown
     */
    public static void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
