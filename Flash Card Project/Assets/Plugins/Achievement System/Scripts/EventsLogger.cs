using UnityEngine;

public class AchievementEventsLogger : MonoBehaviour
{
    [Header("Logging Options")]
    [SerializeField] private bool logAchievementGet = true;
    [SerializeField] private bool logTieredAchievementProgressed = true;

    [SerializeField] private bool logQuestionAnswered = true;
    [SerializeField] private bool logRoundEnded = true;
    [SerializeField] private bool logHuhButton = true;

    private void Awake()
    {
        AchievementEvents.OnAchievementGet += (AchievementEvents.OnAchievementGetArgs args) =>
        {
            if (!logAchievementGet) return;
            Debug.Log($"{args.AchievementObtained.AchievementTitle} Achieved!");
        };

        AchievementEvents.OnTieredAchievementProgressed += (AchievementEvents.OnTieredAchievementProgressedArgs args) =>
        {
            if (!logTieredAchievementProgressed) return;
            string progress = $"{args.tieredAchievement.GetProgressValue()} / {args.tieredAchievement.GetTierRequirement()}";
            Debug.Log($"{args.tieredAchievement.AchievementTitle} was progressed! Now it is {progress}");
        };

        AchievementEvents.OnQuestionAnswered += (AchievementEvents.OnQuestionAnsweredArgs args) =>
        {
            if (!logQuestionAnswered) return;
            string correctText = args.AnsweredCorrectly ? "correctly" : "incorrectly";
            Debug.Log($"Question Answered! Answered {correctText} with {args.TimeRemaining} seconds remaining!");
        };

        AchievementEvents.OnRoundEnded += (AchievementEvents.OnRoundEndedArgs args) =>
        {
            if (!logRoundEnded) return;
            string questionsCorrectRatio = $"{args.NumCorrectQuestions} / {args.NumQuestionsAnswered}";
            Debug.Log($"Round Ended! Answered {questionsCorrectRatio} questions correctly in a total of {args.TotalTimeTaken} seconds!");
        };

        AchievementEvents.OnQuestionClicked += () =>
        {
            if (!logHuhButton) return;
            Debug.Log("Huh?");
        };
    }
}