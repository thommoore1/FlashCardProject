using UnityEngine;

public abstract class TieredAchievement : Achievement
{
    public override string AchievementTitle => $"{GetType()} {RomanNumerals.ToRoman(_currentTierIndex+1)}";
    public override string AchievementDescription => _currentTier.TierDescription;
    public override Sprite AchievementThumbnail => _currentTier.TierThumbnail;
    
    [System.Serializable]
    public class Tier
    {
        public int Requirement;
        public string TierDescription;
        public Sprite TierThumbnail;

        [HideInInspector]
        public bool Achieved;
    }

    [SerializeField] private Tier[] _tiers;
    private Tier _currentTier; // Refers to the tier you are currently trying to complete
    private int _currentTierIndex;

    private int _progress;

    public int GetProgressValue() => _progress;
    public int GetTierRequirement() => _currentTier.Requirement;
    public float GetProgressPercentage() => (float)GetProgressValue() / GetTierRequirement();

    protected void IncrementProgress()
    {
        _progress++;

        AchievementEvents.OnTieredAchievementProgressed.Invoke(new AchievementEvents.OnTieredAchievementProgressedArgs
        {
            tieredAchievement = this,
        });

        if (!IsMaxed && _progress >= _currentTier.Requirement)
        {
            IncreaseTier();
        }
    }

    private void IncreaseTier()
    {
        GetAchievement();

        _currentTier.Achieved = true;

        bool isLastTier = _currentTierIndex == _tiers.Length - 1;
        if (!isLastTier)
        {
            _currentTierIndex++;
            _currentTier = _tiers[_currentTierIndex];
        }

        AchievementEvents.OnTieredAchievementProgressed.Invoke(new AchievementEvents.OnTieredAchievementProgressedArgs
        {
            tieredAchievement = this,
        });
    }

    public override bool IsMaxed => (_currentTierIndex == _tiers.Length - 1) && _currentTier.Achieved;

    public override void Save()
    {
        base.Save();
        PlayerPrefs.SetInt(AchievementSaveKey + "_progress", _progress);

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
        base.Load();
        _progress = PlayerPrefs.GetInt(AchievementSaveKey + "_progress", 0);

        string tierString = PlayerPrefs.GetString(AchievementSaveKey + "_tiers", "");
        string[] states = tierString.Split(',');

        _currentTier = _tiers[0];
        _currentTierIndex = 0;

        for (int i = 0; i < _tiers.Length; i++)
        {
            bool stringHasTierData = i < states.Length;
            if (!stringHasTierData)
            {
                _tiers[i].Achieved = false;
                continue;
            }

            // Determine what is the current tier based off of data
            _tiers[i].Achieved = states[i] == "1";
            if (_tiers[i].Achieved)
            {
                _currentTierIndex = Mathf.Clamp(_currentTierIndex+1, 0, _tiers.Length-1);
                _currentTier = _tiers[_currentTierIndex];
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