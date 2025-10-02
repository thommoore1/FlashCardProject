using System.Collections.Generic;
using UnityEngine;

public class AchievementRegistry : MonoBehaviour
{
    [System.Serializable]
    public struct Mapping
    {
        public AchievementType type;
        public Achievement achievement;
    }

    [SerializeField] private List<Mapping> mappings = new List<Mapping>();

    private Dictionary<AchievementType, Achievement> registry = new Dictionary<AchievementType, Achievement>();

    private void Awake()
    {
        Debug.LogWarning($"{mappings.Count}");
        registry.Clear();
        foreach (var m in mappings)
        {
            if (m.achievement == null) continue;
            if (registry.ContainsKey(m.type))
            {
                Debug.LogWarning($"Duplicate achievement registration for {m.type}. Skipping.");
                continue;
            }
            registry.Add(m.type, m.achievement);
        }
    }

    private void OnEnable()
    {
        QuestionHandler.AnswerSelected += OnAnswerSelected;
    }

    private void OnDisable()
    {
        QuestionHandler.AnswerSelected -= OnAnswerSelected;
    }

    private void OnAnswerSelected(bool isCorrect, float timeLeft)
    {
        // Forward to every registered achievement that cares about answer-selected events.
        // kv is key value pair
        foreach (var kv in registry)
        {
            var achieve = kv.Value;
            if (achieve != null)
                achieve.HandleAnswerSelected(isCorrect, timeLeft);
        }
    }

    // Optional helper to get an achievement by enum
    public Achievement Get(AchievementType type)
    {
        registry.TryGetValue(type, out var a);
        return a;
    }
    

}