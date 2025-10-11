using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListItemResults : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image icon;
    [SerializeField] private Image panel;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private Slider progressSlider;

    [Header("Visuals")]
    [SerializeField] private Color NotUnlockedColor;
    [SerializeField] private Color NormalColor;
    [SerializeField] private Color MaxedColor;

    private CanvasGroup canvasGroup;
    private Achievement trackedAchievement;
    private bool unlockedThisRound;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        SetVisible(false); // Hide initially
    }

    #region Public API
    // Assign the achievement this prefab will track
    public void TrackAchievement(Achievement achievement)
    {
        trackedAchievement = achievement;
        Debug.Log($"Tracking achievement: {achievement.AchievementTitle}");

        // Initially, UI will remain hidden until unlockedThisRound = true
        UpdateUI();
    }

    // Optional: allow opacity adjustments (e.g., for scroll fade)
    public void SetOpacity(float newOpacity)
    {
        canvasGroup.alpha = Mathf.Clamp(newOpacity, 0f, 1f);
    }
    #endregion

    #region Event Handling
    private void OnEnable()
    {
        // Subscribe to the achievement-get event
        AchievementEvents.OnAchievementGet += HandleAchievementGet;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid duplicate calls
        AchievementEvents.OnAchievementGet -= HandleAchievementGet;
    }

    private void HandleAchievementGet(AchievementEvents.OnAchievementGetArgs args)
    {
        Achievement achievement = args.AchievementObtained;

        // Only unlock if this prefab is tracking this achievement
        if (achievement == trackedAchievement)
        {
            unlockedThisRound = true;
            Debug.Log($"Achievement unlocked this round: {achievement.AchievementTitle}");

            UpdateUI();
            SetVisible(true);
        }
    }
    #endregion

    #region UI Update
    private void UpdateUI()
    {
        if (trackedAchievement == null) return;

        Debug.Log($"Updating UI for achievement: {trackedAchievement.AchievementTitle}");

        // Always populate the fields
        titleText.text = trackedAchievement.AchievementTitle;
        descriptionText.text = trackedAchievement.AchievementDescription;
        icon.sprite = trackedAchievement.AchievementThumbnail;

        panel.color = trackedAchievement.HasAchievement ? NormalColor : NotUnlockedColor;

        if (trackedAchievement is TieredAchievement tiered)
        {
            progressSlider.value = tiered.GetProgressPercentage();
            progressText.text = $"{tiered.GetProgressValue()} / {tiered.GetTierRequirement()}";
            if (tiered.IsMaxed) panel.color = MaxedColor;
        }
        else
        {
            progressSlider.value = trackedAchievement.HasAchievement ? 1f : 0f;
            int progress = trackedAchievement.HasAchievement ? 1 : 0;
            progressText.text = $"{progress} / 1";
            if (trackedAchievement.HasAchievement) panel.color = MaxedColor;
        }

        // Visibility controlled by whether it was unlocked this round
        panel.color = MaxedColor;
        SetVisible(unlockedThisRound);
    }

    private void SetVisible(bool visible)
    {
        canvasGroup.alpha = visible ? 1f : 0f;
        canvasGroup.interactable = visible;
        canvasGroup.blocksRaycasts = visible;
    }
    #endregion
}
