using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(Huh), fileName = nameof(Huh))]
public class Huh : Achievement
{
    public override void Subscribe()
    {
        AchievementEvents.OnQuestionClicked += OnQuestionClicked;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnQuestionClicked -= OnQuestionClicked;
    }

    private void OnQuestionClicked()
    {
        GetAchievement();
    }

}
