/*
Names: Tom Moore and Sammy Rokaw
Emails: thomoore@chapman.edu rokaw@chapman.edu
ID: Tom: 2444464 Sammy: 2444664
Course: GAME245-01
Assignment 1
  */ 
using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public QuestionHandler qHandler;
    public TMP_Text countdownText;
    public TMP_Text otherText;
    public UI ui;
    public void startButton()
    {
        StartCoroutine(countdown());
    }

    private IEnumerator countdown()
    {
        ui.HidesGame();
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
