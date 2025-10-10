using System.Collections.Generic;
using UnityEngine;

public class AchievementListUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AchievementListItemUI achievementListItemUIPrefab;
    [SerializeField] private Transform achievementUiParent;
    [SerializeField] private RectTransform scrollRectViewport;

    [Space, Header("Visuals")]
    [SerializeField] private float fadeTransitionDist = 100f;

    private List<AchievementListItemUI> achievementUis = new List<AchievementListItemUI>();

    private void Start()
    {
        ClearAchievementObjects();

        // Listen for new achievements unlocked this round
        AchievementEvents.OnAchievementGet += OnAchievementGet;
        AchievementEvents.OnRoundEnded += _ => ClearAchievementObjects();
    }

    private void OnDestroy()
    {
        // Always unsubscribe to prevent memory leaks
        AchievementEvents.OnAchievementGet -= OnAchievementGet;
        AchievementEvents.OnRoundEnded -= _ => ClearAchievementObjects();
    }

    private void Update()
    {
        SetAchievementsOpacity();
    }

    private void OnAchievementGet(AchievementEvents.OnAchievementGetArgs args)
    {
        Achievement achievement = args.AchievementObtained;

        // Create UI for this newly unlocked achievement
        AchievementListItemUI achievementUI = Instantiate(achievementListItemUIPrefab, achievementUiParent);
        achievementUis.Add(achievementUI);
        achievementUI.TrackAchievement(achievement);
    }

    private void ClearAchievementObjects()
    {
        foreach (Transform child in achievementUiParent.transform)
        {
            Destroy(child.gameObject);
        }
        achievementUis.Clear();
    }

    private void SetAchievementsOpacity()
    {
        if (achievementUis.Count == 0) return;

        Vector3[] worldCorners = new Vector3[4];
        scrollRectViewport.GetWorldCorners(worldCorners);
        float viewportEdgeTop = worldCorners[2].y;
        float viewportEdgeBottom = worldCorners[0].y;

        foreach (AchievementListItemUI achievementUI in achievementUis)
        {
            RectTransform rect = achievementUI.GetComponent<RectTransform>();
            rect.GetWorldCorners(worldCorners);
            float achievementEdgeTop = worldCorners[2].y;
            float achievementEdgeBottom = worldCorners[0].y;

            float distanceOutOfBounds = Mathf.Max(achievementEdgeTop - viewportEdgeTop, 0.0f)
                                      + Mathf.Max(viewportEdgeBottom - achievementEdgeBottom, 0.0f);
            float opacity = 1.0f - Mathf.Clamp(distanceOutOfBounds / fadeTransitionDist, 0.0f, 1.0f);
            achievementUI.SetOpacity(opacity);
        }
    }
}
