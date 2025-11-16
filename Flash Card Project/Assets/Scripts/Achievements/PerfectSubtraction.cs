using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PerfectSubtraction), fileName = nameof(PerfectSubtraction))]
public class PerfectSubtraction : Achievement
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
        if (StateManager.currentState == States.Subtracting && obj.NumCorrectQuestions == obj.NumQuestionsAnswered)
        {
            GetAchievement();
        }
    }
    
}
