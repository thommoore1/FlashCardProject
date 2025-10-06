using System;

public static class AchievementEvents
{
    // On Achievement Get
    public static Action<OnAchievementGetArgs> OnAchievementGet;
    public struct OnAchievementGetArgs
    {
        public Achievement AchievementObtained;
    }
    
    // On Round Ended 
    public static Action<OnRoundEndedArgs> OnRoundEnded;
    public struct OnRoundEndedArgs
    {
        public int NumQuestionsAnswered;
        public int NumCorrectQuestions;
        public float TotalTimeTaken;
    }
    
    // On Question Answered
    public static Action<OnQuestionAnsweredArgs> OnQuestionAnswered;
    public struct OnQuestionAnsweredArgs
    {
        public bool AnsweredCorrectly;
        public float TimeRemaining;
    }

    // On Question Clicked
    public static Action OnQuestionClicked;
    
    // On Second Passed
    public static Action OnSecondPassed;
}
