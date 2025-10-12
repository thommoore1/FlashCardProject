# Achievements

## Integration Per-Project
- Add the `AchievementManager` MonoBehaviour to a new `GameObject`
  - Optionally add `EventsLogger` to the same `GameObject`
- Hook up all AchievementEvents that say `(Invoke this on a per project basis)`
    - For example, here's what you'd call when the round ends:
    -         AchievementEvents.OnRoundEnded?.Invoke(new AchievementEvents.OnRoundEndedArgs
              {
                  NumQuestionsAnswered = questionsAnswered,
                  NumCorrectQuestions = correctQuestionCount,
                  TotalTimeTaken = Time.time - timeStarted,
              });

## Adding A New Achievement
- Subclass `Achievement`
- Make sure you have a `CreateAssetMenu` attribute (see `MathMaster` for an example)
- Implement the `Subscribe` and `Unsubscribe` method to listen to the appropriate method in `AchievementEvents`
- Call GetAchievement when
- If your achievement requires any special Save and Load functionality, make sure to override those!
  - Still call `base.Load();` and `base.Save();`
  - `Achievement` handles saving of completion in GetAchievement
- Make sure to create an instance of the achievement in `Resources/Achievements`