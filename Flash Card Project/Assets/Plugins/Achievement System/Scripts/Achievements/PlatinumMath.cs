using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PlatinumMath), fileName = nameof(PlatinumMath))]
public class PlatinumMath : Achievement
{

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
        GetAchievement();
    }
    
}
