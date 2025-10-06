# Achievements

## Adding a new achievement
- Subclass achievement
- Implement the `Subscribe` method based on the appropriate method in `AchievementEvents`
- Ensure that GameEvents has the appropriate method hooked up!
  - For example, here's what you'd call when the round ends:
  -         AchievementEvents.OnRoundEnded?.Invoke(new AchievementEvents.OnRoundEndedArgs
            {
                NumQuestionsAnswered = questionsAnswered,
                NumCorrectQuestions = correctQuestionCount,
                TotalTimeTaken = Time.time - timeStarted,
            });
- Make sure to create an instance of the achievement in `Resources/Achievements`