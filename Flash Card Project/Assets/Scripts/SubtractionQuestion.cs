/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 3
 *
 * 2)
 * This file is used to generate the Subtraction questions for the flash cards
 */
using UnityEngine;

public class SubtractionQuestion : Question
{
    private int int1;
    private int int2;

    public SubtractionQuestion() : base("", "" , "", "", 1)
    {
        GenerateQuestion();
    }
    
    
    protected override void GenerateQuestion()
    {
        int1 = Random.Range(1, 13);
        int2 = Random.Range(1, 13);
        base.GenerateQuestion();
        questionString = int1.ToString() + "-" + int2.ToString();
    }
    // makes the right answer
    protected override void GenerateCorrectAnswer()
    {
        correctAnswerString = (int1 - int2).ToString();
    }
    
    //calls both wrong answer methods
    
    protected override void GenerateIncorrectAnswers()
    {
        incorrectAnswer2String = makeHigherWrongAnswer().ToString();
        incorrectAnswerString = makeLowerWrongAnswer().ToString();
    }
    
    
    /*
     * a. makeLowerWrongAnswer()
     * b. Returns an int representing the lower end of the wrong answers
     * c. Does not take in value
     * d. No exceptions thrown
     */
    private int makeLowerWrongAnswer()
    {
        if (int2 > 1)
        {
            return int1 - (int2 - 1);
        }
        else
        {
            return int1 - (int2 + 2);
        }
    }
    /*
     * a. makeHigherWrongAnswer()
     * b. Returns an int representing the higher end of the wrong answers
     * c. Does not take in value
     * d. No exceptions thrown
     */
    private int makeHigherWrongAnswer()
    {
        if (int2 < 12)
        {
            return int1 - (int2 + 1);
        }
        else
        {
            return int1 - (int2 - 2);
        }
    }
}
