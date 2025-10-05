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

    private void HandleRoundCompleted(int correct, int total)
    {
        if (correct == total)
        {
            perfectRounds++;
            Save();

            Debug.Log($"✅ Perfect round! Total perfects: {perfectRounds}");

            if (perfectRounds == 1)
                Debug.Log("🏅 Achievement Unlocked: Gold Star I (1 Perfect Round)");
            else if (perfectRounds == 10)
                Debug.Log("🏅 Achievement Unlocked: Gold Star II (10 Perfect Rounds)");
            else if (perfectRounds == 30)
                Debug.Log("🏅 Achievement Unlocked: Gold Star III (30 Perfect Rounds)");
        }
        else
        {
            Debug.Log("❌ Not a perfect round.");
        }
    }

    public override void Save()
    {
        PlayerPrefs.SetInt("GoldStarPerfectRounds", perfectRounds);
        PlayerPrefs.Save();
    }

    public override void Load()
    {
        perfectRounds = PlayerPrefs.GetInt("GoldStarPerfectRounds", 0);
    }
}