using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PerfectDivision), fileName = nameof(PerfectDivision))]
public class PerfectDivision : Achievement
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
        if (StateManager.currentState == States.Dividing && obj.NumCorrectQuestions == obj.NumQuestionsAnswered)
        {
            GetAchievement();
        }
    }
    
}
