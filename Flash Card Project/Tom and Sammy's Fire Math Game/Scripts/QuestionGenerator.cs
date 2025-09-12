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
    public int int1; // first value
    public int int2; //second value
    public int cAnswerPos; // position value of correct answer
    
    /*
     * a. GenerateQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public void GenerateQuestion()
    {
        int1 = Random.Range(1, 13);
        int2 = Random.Range(1, 13);
        qText.text = int1.ToString() + "x" + int2.ToString();
        cAnswerPos = Random.Range(1, 4);
        switch (cAnswerPos)
        {
            case 1:
                aText.text = (int1 * int2).ToString();
                bText.text = makeLowerWrongAnswer().ToString();
                cText.text = makeHigherWrongAnswer().ToString();
                break;
            case 2:
                aText.text = makeLowerWrongAnswer().ToString();
                bText.text = (int1 * int2).ToString();
                cText.text = makeHigherWrongAnswer().ToString();
                break;
            case 3:
                aText.text = makeHigherWrongAnswer().ToString();
                bText.text = makeLowerWrongAnswer().ToString();
                cText.text = (int1 * int2).ToString();
                break;
        }
    }

    /*
     * a. makeLowerWrongAnswer()
     * b. Returns an int representing the lower end of the wrong answers
     * c. Does not take in value
     * d. No exceptions thrown
     */

    public void reset()
    {
        qText.text = "?";
        aText.text = "";
        bText.text = "";
        cText.text = "";
    }
    private int makeLowerWrongAnswer()
    {
        if (int2 > 1)
        {
            return int1 * (int2 - 1);
        }
        else
        {
            return int1 * (int2 + 2);
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
            return int1 * (int2 + 1);
        }
        else
        {
            return int1 * (int2 - 2);
        }
    }
    
    /*
     * a. getCorrectAnswer()
     * b. Returns an int representing correctAnswer
     * c. Does not take in value
     * d. No exceptions thrown
     */
    public int getCorrectAnswer()
    {
        return cAnswerPos;
    }
}
