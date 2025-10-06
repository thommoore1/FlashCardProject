using System;
using UnityEngine;

public static class GameEvents
{
    // Called when a round is completed
    public static event Action<int, int, int> OnRoundCompleted; 
    // args: correctAnswers, totalQuestions

    public static void RoundCompleted(int correctAnswers, int totalQuestions, int timeTaken)
    {
        Debug.Log($"Correct Answers: {correctAnswers}, Total Questions: {totalQuestions}, Time Taken: {timeTaken}");
        OnRoundCompleted?.Invoke(correctAnswers, totalQuestions, timeTaken);
    }
}