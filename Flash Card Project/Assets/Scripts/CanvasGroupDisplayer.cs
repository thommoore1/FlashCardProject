/*
Names: Tom Moore and Sammy Rokaw
Emails: thomoore@chapman.edu rokaw@chapman.edu
ID: Tom: 2444464 Sammy: 2444664
Course: GAME245-01
Assignment 1
  */ 
using UnityEngine;

public static class CanvasGroupDisplayer
{
    public static void Show(CanvasGroup canvasGroup) //makes a canvas visible and interactable
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public static void Hide(CanvasGroup canvasGroup) // makes a canvas invisible and uninteractable
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
