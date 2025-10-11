using System.Collections.Generic;
using UnityEngine;

public class AchievemtnsUIResults : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ListItemResults achievementListItemUIPrefab;
    [SerializeField] private Transform achievementUiParent;
    [SerializeField] private RectTransform scrollRectViewport;

    [Space, Header("Visuals")]
    [SerializeField] private float fadeTransitionDist = 100;

    private List<ListItemResults> achievementUis = new List<ListItemResults>();

    // Keep strong references to handlers so we can unsubscribe properly
    private System.Action<AchievementEvents.OnAchievementGetArgs> onAchievementGetHandler;
    
    private System.Action<AchievementEvents.OnRoundStartArgs> onRoundStartHandler;

    private void OnEnable()
    {
        // Define handlers ONCE
        onAchievementGetHandler = OnAchievementGet;
        onRoundStartHandler = OnRoundStart;

        // Subscribe them
        AchievementEvents.OnAchievementGet += onAchievementGetHandler;
        AchievementEvents.OnRoundStart += onRoundStartHandler;
    }

    private void OnDisable()
    {
        // Safely unsubscribe to prevent duplicates
        AchievementEvents.OnAchievementGet -= onAchievementGetHandler;
        AchievementEvents.OnRoundStart -= onRoundStartHandler;
    }

    private void OnRoundStart(AchievementEvents.OnRoundStartArgs args)
    {
        ClearAchievementObjects();
    }

    private void OnAchievementGet(AchievementEvents.OnAchievementGetArgs args)
    {
        Achievement achievement = args.AchievementObtained;

        // Instantiate prefab
        ListItemResults newUI = Instantiate(achievementListItemUIPrefab, achievementUiParent);
        achievementUis.Add(newUI);

        // Update UI for this specific achievement
        newUI.TrackAchievement(achievement);
    }


    private void Update()
    {
        SetAchievementsOpacity();
    }

    private void ClearAchievementObjects()
    {
        foreach (Transform child in achievementUiParent)
        {
            Destroy(child.gameObject);
        }
        achievementUis.Clear();
    }

    private void SetAchievementsOpacity()
    {
        Vector3[] worldCorners = new Vector3[4];
        scrollRectViewport.GetWorldCorners(worldCorners);
        float viewportEdgeTop = worldCorners[2].y;
        float viewportEdgeBottom = worldCorners[0].y;

        foreach (ListItemResults achievementUI in achievementUis)
        {
            achievementUI.GetComponent<RectTransform>().GetWorldCorners(worldCorners);
            float achievementEdgeTop = worldCorners[2].y;
            float achievementEdgeBottom = worldCorners[0].y;

            float distanceOutOfBounds = Mathf.Max(achievementEdgeTop - viewportEdgeTop, 0.0f) +
                                        Mathf.Max(viewportEdgeBottom - achievementEdgeBottom, 0.0f);

            float opacity = 1.0f - Mathf.Clamp(distanceOutOfBounds / fadeTransitionDist, 0.0f, 1.0f);
            achievementUI.SetOpacity(opacity);
        }
    }
}
