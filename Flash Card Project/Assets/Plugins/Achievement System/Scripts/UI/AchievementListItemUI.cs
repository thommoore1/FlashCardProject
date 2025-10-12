using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListItemUI : MonoBehaviour
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

    Achievement trackedAchievement;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void TrackAchievement(Achievement achievement)
    {
        trackedAchievement = achievement;
        AchievementEvents.OnAchievementGet += _ => UpdateUI();
        AchievementEvents.OnTieredAchievementProgressed += _ => UpdateUI();
        UpdateUI();
    }

    public void UpdateUI()
    {
        titleText.text = trackedAchievement.AchievementTitle;
        descriptionText.text = trackedAchievement.AchievementDescription;
        icon.sprite = trackedAchievement.AchievementThumbnail;

        panel.color = trackedAchievement.HasAchievement ? NormalColor : NotUnlockedColor;

        if (trackedAchievement is TieredAchievement)
        {
            TieredAchievement tieredAchievement = trackedAchievement as TieredAchievement;
            progressSlider.value = tieredAchievement.GetProgressPercentage();
            progressText.text = $"{tieredAchievement.GetProgressValue()} / {tieredAchievement.GetTierRequirement()}";
            if (tieredAchievement.IsMaxed) { panel.color = MaxedColor; }
        }
        else
        {
            progressSlider.value = trackedAchievement.HasAchievement ? 1.0f : 0.0f;
            int progress = trackedAchievement.HasAchievement ? 1 : 0;
            progressText.text = $"{progress} / {1}";
            if (trackedAchievement.HasAchievement) { panel.color = MaxedColor; }
        }
    }

    public void SetOpacity(float newOpacity)
    {
        canvasGroup.alpha = Mathf.Clamp(newOpacity, 0.0f, 1.0f);
    }
}
