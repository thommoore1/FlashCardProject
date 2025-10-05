using System;
using UnityEngine;

public static class GameEvents
{
    // Called when a round is completed
    public static event Action<int, int> OnRoundCompleted; 
    // args: correctAnswers, totalQuestions

    public static void RoundCompleted(int correctAnswers, int totalQuestions)
    {
        OnRoundCompleted?.Invoke(correctAnswers, totalQuestions);
    }
}