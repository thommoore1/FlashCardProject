using UnityEngine;

public abstract class Achievement : ScriptableObject
{
    public virtual string AchievementTitle => GetType().ToString();
    
    [TextArea]
    public string Description;
    public Sprite Thumbnail;

    protected string AchievementSaveKey => GetType().Name;
    
    public abstract void Subscribe();
    public abstract void Unsubscribe();
    
    protected void GetAchievement()
    {
        Debug.Log($"{AchievementTitle} Achieved!");
        AchievementEvents.OnAchievementGet?.Invoke(new AchievementEvents.OnAchievementGetArgs
        {
            AchievementObtained = this
        });
    }

    public abstract void Save();

    public abstract void Load();
}
