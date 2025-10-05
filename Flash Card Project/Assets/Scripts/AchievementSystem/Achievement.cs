using UnityEngine;

public abstract class Achievement : ScriptableObject
{
    [Header("Achievement Info")]
    public string achievementName;
    public string description;

    // These must be abstract so child classes can override them
    public abstract void Subscribe();
    public abstract void Unsubscribe();
    public abstract void Save();
    public abstract void Load();
}