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
using System.Collections.Generic;
public class QuizGenerator : MonoBehaviour
{
    public TMP_Text qText; //text refrence for question text
    public TMP_Text aText; //text refrence for button a text
    public TMP_Text bText; //text refrence for button b text
    public TMP_Text cText; // text refrence for button c text
    public List<Question> quiz;

    public int qIndex;
    
    /*
     * a. GenerateQuestion()
     * b. Does not return a value
     * c. Does not take in value
     * d. No exceptions thrown
     */

    public void GenerateQuiz(int numQuestions, int questionType)
    {
        quiz = new List<Question>();
        qIndex = 0;
        for (int i = 0; i < numQuestions; i++)
        {
            addQuestion(questionType);
        }
        displayQuestion();
    }

    public void nextQuestion()
    {
        qIndex++;
        displayQuestion();
    }

    public void prevQuestion()
    {
        qIndex--;
        displayQuestion();
    }

    private void addQuestion(int questionType)
    {
        if (questionType != 5)
        {
            pickQuestion(questionType);
        }
        else
        {
            int randomQ = Random.Range(1, 5);
            pickQuestion(randomQ);
        }
        
    }

    private void pickQuestion(int questionType)
    {
        switch (questionType)
        {
            case 1:
                quiz.Add(new AdditionQuestion());
                break;
            case 2:
                quiz.Add(new SubtractionQuestion());
                break;
            case 3:
                quiz.Add(new MultiplicationQuestion());
                break;
            case 4:
                quiz.Add(new DivisionQuestion());
                break;
        }
    }
    
    private void displayQuestion()
    {
        qText.text = quiz[qIndex].questionString;
        switch (quiz[qIndex].correctAnswerPos)
        {
            case 1:
                aText.text = quiz[qIndex].correctAnswerString;
                bText.text = quiz[qIndex].incorrectAnswerString;
                cText.text = quiz[qIndex].incorrectAnswer2String;
                break;
            case 2:
                aText.text = quiz[qIndex].incorrectAnswerString;
                bText.text = quiz[qIndex].correctAnswerString;
                cText.text = quiz[qIndex].incorrectAnswer2String;
                break;
            case 3:
                aText.text = quiz[qIndex].incorrectAnswer2String;
                bText.text = quiz[qIndex].incorrectAnswerString;
                cText.text = quiz[qIndex].correctAnswerString;
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
        return quiz[qIndex].correctAnswerPos;
    }
}
