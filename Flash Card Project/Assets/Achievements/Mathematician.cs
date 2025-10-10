using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(Mathematician), fileName = nameof(Mathematician))]
public class Mathematician : Achievement
{
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
        if (totalSeconds >= 12)
        {
            GetAchievement();
        }
    }
}
