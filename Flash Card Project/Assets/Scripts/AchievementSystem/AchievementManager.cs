using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private Achievement[] achievements;

    private void Awake()
    {
        foreach (var achievement in achievements)
        {
            achievement.Subscribe(); // ✅ use Subscribe instead of Initialize
        }
    }

    private void OnDestroy()
    {
        foreach (var achievement in achievements)
        {
            achievement.Unsubscribe();
        }
    }
}
