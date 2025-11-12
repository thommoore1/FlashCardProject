using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PerfectMultiplication), fileName = nameof(PerfectMultiplication))]
public class PerfectMultiplication : Achievement
{
    public override void Subscribe()
    {
        AchievementEvents.OnRoundEnded += OnRoundEnded;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnRoundEnded -= OnRoundEnded;
    }

    private void OnRoundEnded(AchievementEvents.OnRoundEndedArgs obj)
    {
        if (obj.QuizType == 3 && obj.NumCorrectQuestions == obj.NumQuestionsAnswered)
        {
            GetAchievement();
        }
    }
    
}
