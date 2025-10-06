using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(GoldStar), fileName = nameof(GoldStar))]
public class GoldStar : TieredAchievement
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
        if (obj.NumCorrectQuestions == obj.NumQuestionsAnswered)
            IncrementProgress();
    }
}