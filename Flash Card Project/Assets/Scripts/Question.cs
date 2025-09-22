/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 1
 *
 * 2)
 * This file is a base Question Class
 */
using UnityEngine;

public class Question : MonoBehaviour
{
    public string questionString;
    public string correctAnswerString;
    public string incorrectAnswerString;
    public string incorrectAnswer2String;
    public int correctAnswerPos;

    public virtual void GenerateQuestion()
    {
        correctAnswerPos = Random.Range(1, 4);
        GenerateCorrectAnswer();
        GenerateIncorrectAnswers();
    }

    protected virtual void GenerateCorrectAnswer()
    {
        
    }

    protected virtual void GenerateIncorrectAnswers()
    {
        
    }
}