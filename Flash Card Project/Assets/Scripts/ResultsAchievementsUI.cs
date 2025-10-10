using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsAchievementUI : MonoBehaviour
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
        SetVisible(false);
    }

    public void TrackAchievement(Achievement achievement)
    {
        trackedAchievement = achievement;
        unlockedThisRound = false;

        // Subscribe with correct signature
        AchievementEvents.OnAchievementGet += args =>
        {
            if (args.AchievementObtained == trackedAchievement)
            {
                unlockedThisRound = true;
                UpdateUI();
                SetVisible(true);
            }
        };

        AchievementEvents.OnTieredAchievementProgressed += args =>
        {
            if (args.tieredAchievement == trackedAchievement)
                UpdateUI();
        };

        UpdateUI();
    }

    private void OnAchievementGet(Achievement achievement)
    {
        // Only show if this is the tracked achievement and it was unlocked this round
        if (achievement == trackedAchievement)
        {
            unlockedThisRound = true;
            UpdateUI();
            SetVisible(true);
        }
    }

    public void UpdateUI()
    {
        if (trackedAchievement == null) return;

        // If it hasn’t been unlocked this round, hide it
        if (!unlockedThisRound)
        {
            SetVisible(false);
            return;
        }

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
            progressSlider.value = trackedAchievement.HasAchievement ? 1.0f : 0.0f;
            int progress = trackedAchievement.HasAchievement ? 1 : 0;
            progressText.text = $"{progress} / {1}";
            if (trackedAchievement.HasAchievement) panel.color = MaxedColor;
        }
    }

    private void SetVisible(bool visible)
    {
        canvasGroup.alpha = visible ? 1f : 0f;
        canvasGroup.interactable = visible;
        canvasGroup.blocksRaycasts = visible;
    }

    public void SetOpacity(float newOpacity)
    {
        canvasGroup.alpha = Mathf.Clamp(newOpacity, 0.0f, 1.0f);
    }
}
