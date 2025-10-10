using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(BuzzerBeater), fileName = nameof(BuzzerBeater))]
public class BuzzerBeater : Achievement
{
    private bool _achievementGotten;
    
    public override void Subscribe()
    {
        AchievementEvents.OnQuestionAnswered += OnQuestionAnswered;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnQuestionAnswered -= OnQuestionAnswered;
    }

    private void OnQuestionAnswered(AchievementEvents.OnQuestionAnsweredArgs obj)
    {
        if (obj.AnsweredCorrectly && obj.TimeRemaining <= 1)
        {
        _achievementGotten = true;
        GetAchievement();
        }
            
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
