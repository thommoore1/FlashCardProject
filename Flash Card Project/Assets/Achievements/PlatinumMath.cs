using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PlatinumMath), fileName = nameof(PlatinumMath))]
public class PlatinumMath : Achievement
{
    private bool _achievementGotten;

    public override void Subscribe()
    {
        AchievementEvents.OnAllAchievementObtained += OnAllAchievementObtained;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnAllAchievementObtained -= OnAllAchievementObtained;
    }

    private void OnAllAchievementObtained()
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
