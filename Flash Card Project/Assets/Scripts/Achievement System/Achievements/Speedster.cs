using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(Speedster), fileName = nameof(Speedster))]
public class Speedster : Achievement
{
    private bool _achievementGotten;

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
            GetAchievement();
    }
    
    public override void Save()
    {
        PlayerPrefs.SetInt(AchievementSaveKey, _achievementGotten ? 1 : 0);
    }

    public override void Load()
    {
        _achievementGotten = PlayerPrefs.GetInt(AchievementSaveKey) == 1 ? true : false;
    }
    
}