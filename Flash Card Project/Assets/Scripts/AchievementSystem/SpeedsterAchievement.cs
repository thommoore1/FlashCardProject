using UnityEngine;

[CreateAssetMenu(fileName = "SpeedsterAchievement", menuName = "Achievements/Speedster")]
public class SpeedsterAchievement : Achievement
{
    private int perfectRounds;

    public override void Subscribe()
    {
        GameEvents.OnRoundCompleted += HandleRoundCompleted;
        Load();
    }

    public override void Unsubscribe()
    {
        GameEvents.OnRoundCompleted -= HandleRoundCompleted;
    }

    private void HandleRoundCompleted(int correct, int total, int time)
    {
        if (correct == total && time <= 10)
        {

            Debug.Log("Achievement acquired: Speedster");
        }
        else
        {
            Debug.Log("❌ Not a perfect round.");
        }
    }

    public override void Save()
    {
    }

    public override void Load()
    {
    }
}