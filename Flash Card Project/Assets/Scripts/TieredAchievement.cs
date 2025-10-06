using UnityEngine;

public abstract class TieredAchievement : Achievement
{
    public override string AchievementTitle => $"{GetType()} {RomanNumerals.ToRoman(GetHighestTierNumber())}";
    
    [System.Serializable]
    public class Tier
    {
        public int Requirement;
        [HideInInspector]
        public bool Achieved;
    }

    [SerializeField] private Tier[] _tiers;
    private int _progress;

    public int GetHighestTierNumber()
    {
        GetHighestTier(out int tierNumber);
        return tierNumber;
    }
    
    public Tier GetHighestTier(out int tierNumber)
    {
        for (int index = _tiers.Length - 1; index >= 0; index--)
        {
            Tier tier = _tiers[index];
            if (_progress >= tier.Requirement)
            {
                tierNumber = index + 1;
                return _tiers[index];
            }
        }
        
        tierNumber = 1;
        return _tiers[0];
    }
    
    protected void IncrementProgress()
    {
        _progress++;

        for (int index = 0; index < _tiers.Length; index++)
        {
            Tier tier = _tiers[index];
            if (!tier.Achieved && _progress >= tier.Requirement)
            {
                tier.Achieved = true;
                GetAchievement();
            }
        }

        Save();
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(AchievementSaveKey, _progress);

        string[] tierStates = new string[_tiers.Length];
        for (int i = 0; i < _tiers.Length; i++)
        {
            tierStates[i] = _tiers[i].Achieved ? "1" : "0";
        }
        string joined = string.Join(",", tierStates);
        PlayerPrefs.SetString(AchievementSaveKey + "_tiers", joined);

        PlayerPrefs.Save();
    }

    public override void Load()
    {
        _progress = PlayerPrefs.GetInt(AchievementSaveKey, 0);

        string tierString = PlayerPrefs.GetString(AchievementSaveKey + "_tiers", "");
        string[] states = tierString.Split(',');

        for (int i = 0; i < _tiers.Length; i++)
        {
            if (i < states.Length)
            {
                _tiers[i].Achieved = states[i] == "1";
            }
            else
            {
                _tiers[i].Achieved = false;
            }
        }
    }
}

public static class RomanNumerals
{
    private static readonly (int value, string symbol)[] _map =
    {
        (1000, "M"),
        (900,  "CM"),
        (500,  "D"),
        (400,  "CD"),
        (100,  "C"),
        (90,   "XC"),
        (50,   "L"),
        (40,   "XL"),
        (10,   "X"),
        (9,    "IX"),
        (5,    "V"),
        (4,    "IV"),
        (1,    "I"),
    };

    public static string ToRoman(int number)
    {
        if (number <= 0) return "";

        string result = "";
        foreach (var (value, symbol) in _map)
        {
            while (number >= value)
            {
                result += symbol;
                number -= value;
            }
        }
        return result;
    }
}
