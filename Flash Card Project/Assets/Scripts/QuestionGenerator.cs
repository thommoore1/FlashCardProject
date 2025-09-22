/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 1
 *
 * 2)
 * This file is used to generate the math questions for the flash cards
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    public TMP_Text qText; //text refrence for question text
    public TMP_Text aText; //text refrence for button a text
    public TMP_Text bText; //text refrence for button b text
    public TMP_Text cText; // text refrence for button c text
    public MultiplicationQuestion mq;
    
    /*
     * a. GenerateQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void GenerateQuestion()
    {
        mq.GenerateQuestion();
        qText.text = mq.questionString;
        switch (mq.correctAnswerPos)
        {
            case 1:
                aText.text = mq.correctAnswerString;
                bText.text = mq.incorrectAnswerString;
                cText.text = mq.incorrectAnswer2String;
                break;
            case 2:
                aText.text = mq.incorrectAnswerString;
                bText.text = mq.correctAnswerString;
                cText.text = mq.incorrectAnswer2String;
                break;
            case 3:
                aText.text = mq.incorrectAnswer2String;
                bText.text = mq.incorrectAnswerString;
                cText.text = mq.correctAnswerString;
                break;
        }
    }

    

    public void reset()
    {
        qText.text = "?";
        aText.text = "";
        bText.text = "";
        cText.text = "";
    }
    
    
    
    /*
     * a. getCorrectAnswer()
     * b. Returns an int representing correctAnswer
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public int getCorrectAnswer()
    {
        return mq.correctAnswerPos;
    }
}
