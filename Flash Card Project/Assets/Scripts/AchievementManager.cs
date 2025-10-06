using System;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public Achievement[] Achievements { get; private set; }

    public void Awake()
    {
        Achievements = Resources.LoadAll<Achievement>("Achievements");
        foreach (Achievement achievement in Achievements)
        {
            achievement.Load();
            achievement.Subscribe();
        }
    }

    public void OnDestroy()
    {
        foreach (Achievement achievement in Achievements)
        {
            achievement.Save();
            achievement.Unsubscribe();
        }
    }

    [ContextMenu("Clear Save")]
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        
        if (!Application.isPlaying) return;
        
        foreach (Achievement achievement in Achievements)
        {
            achievement.Load();
        }
    }
}
