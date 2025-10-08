using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(Mathematician), fileName = nameof(Mathematician))]
public class Mathematician : Achievement
{
    private bool _achievementGotten;
    private float totalSeconds;
    
    public override void Subscribe()
    {
        AchievementEvents.OnSecondPassed += OnSecondPassed;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnSecondPassed -= OnSecondPassed;
    }

    private void OnSecondPassed()
    {
        totalSeconds++;
        if (totalSeconds >= 1200)
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
