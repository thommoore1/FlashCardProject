using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PerfectAddition), fileName = nameof(PerfectAddition))]
public class PerfectAddition : Achievement
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
        if (StateManager.currentState == States.Adding && obj.NumCorrectQuestions == obj.NumQuestionsAnswered)
        {
            GetAchievement();
        }
    }
    
}
