using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    public Achievement[] Achievements { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        InitializeAchievements();
    }

    private void InitializeAchievements()
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