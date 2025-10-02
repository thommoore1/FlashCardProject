using UnityEngine;
using UnityEngine.Events;
public class Achievement : MonoBehaviour
{
    [SerializeField] private string title = "";
    [SerializeField][TextArea] private string description = "";
    [SerializeField] private float unlockTimeThreshold = 1f; // seconds remaining to qualify
    public bool IsUnlocked { get; private set; }
    

    private void OnEnable()
    {
        QuestionHandler.AnswerSelected += HandleAnswerSelected;
    }

    private void OnDisable()
    {
        QuestionHandler.AnswerSelected -= HandleAnswerSelected;
    }
    public void HandleAnswerSelected(bool isCorrect, float timeLeft)
    {
        if (IsUnlocked) return;
        if (isCorrect && timeLeft <= unlockTimeThreshold)
        {
            title = title == "" ? "Achievement" : title;
            description = $"Answered correctly with {timeLeft:F1} seconds left!";
            Unlock();
        }
       
    }
    private void Start()
    {
        IsUnlocked = false;
    }

    public void Unlock()
    {
        if (IsUnlocked) return;
        IsUnlocked = true;
        Debug.Log($"Achievement Unlocked: {title} - {description}");
        // TODO: persist achievement, trigger UI, play SFX, etc.
    }
}

    

