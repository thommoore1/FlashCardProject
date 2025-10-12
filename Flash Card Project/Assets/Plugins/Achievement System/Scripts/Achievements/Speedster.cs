using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(Speedster), fileName = nameof(Speedster))]
public class Speedster : Achievement
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
        if (obj.TotalTimeTaken <= 10f && obj.NumCorrectQuestions == obj.NumQuestionsAnswered)
        {
            GetAchievement();
        }
    }

    
}
