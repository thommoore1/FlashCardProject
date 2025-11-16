using System;

public static class AchievementEvents
{
    // On Achievement Get (Already invoke by the system)
    public static Action<OnAchievementGetArgs> OnAchievementGet;
    public struct OnAchievementGetArgs
    {
        public Achievement AchievementObtained;
    }

    // On Tiered Achievement Progressed (Already invoke by the system)
    public static Action<OnTieredAchievementProgressedArgs> OnTieredAchievementProgressed;
    public struct OnTieredAchievementProgressedArgs
    {
        public TieredAchievement tieredAchievement;
    }
    
    // On Round Ended (Invoke this on a per project basis)
    public static Action<OnRoundEndedArgs> OnRoundEnded;
    public struct OnRoundEndedArgs
    {
        public States QuizType;
        public int NumQuestionsAnswered;
        public int NumCorrectQuestions;
        public float TotalTimeTaken;
    }
    
    // On Question Answered (Invoke this on a per project basis)
    public static Action<OnQuestionAnsweredArgs> OnQuestionAnswered;
    public struct OnQuestionAnsweredArgs
    {
        public bool AnsweredCorrectly;
        public float TimeRemaining;
    }

    // On Question Clicked (Invoke this on a per project basis)
    public static Action OnQuestionClicked;
    
    // On Second Passed (Invoke this on a per project basis)
    public static Action OnSecondPassed;
    
    public static Action OnAllAchievementObtained;

    public static Action<OnRoundStartArgs> OnRoundStart;
    public struct OnRoundStartArgs
    {
    }
}