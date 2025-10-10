using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(Huh), fileName = nameof(Huh))]
public class Huh : Achievement
{
    private bool _achievementGotten;
    
    public override void Subscribe()
    {
        AchievementEvents.OnQuestionClicked += OnQuestionClicked;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnQuestionClicked -= OnQuestionClicked;
    }

    private void OnQuestionClicked()
    {
        _achievementGotten = true;
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
