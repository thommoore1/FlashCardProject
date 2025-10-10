using System;
using UnityEngine;

public class AchievementChecker : MonoBehaviour
{
    private AchievementManager manager;
    
    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }
    
    private void Subscribe()
    {
        AchievementEvents.OnAchievementGet += OnAchievementGet;
    }
    private void Unsubscribe()
    {
        AchievementEvents.OnAchievementGet += OnAchievementGet;
    }
    
    private void Awake()
    {
        manager = gameObject.GetComponent<AchievementManager>();
    }

    private void OnAchievementGet(AchievementEvents.OnAchievementGetArgs args)
    {
        bool allCompleted = true;
        foreach (Achievement achievement in manager.Achievements)
        {
            if (!achievement.checkStatus() && achievement.AchievementTitle != "PlatinumMath")
            {
                allCompleted = false;
            }
        }

        if (allCompleted)
        {
            AchievementEvents.OnAllAchievementObtained.Invoke();
        }
    }
    
}
