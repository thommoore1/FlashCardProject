=====================================================
 ACHIEVEMENT SYSTEM - GOLD STAR EXAMPLE
=====================================================

Author(s): Team KITTY MEOW MEOW
Purpose:  Shared modular achievement system for integration between groups.

-----------------------------------------------------
🧩 INCLUDED FILES
-----------------------------------------------------
1. Achievement.cs
   - Base ScriptableObject class for achievements.
   - Contains Save and Load logic using PlayerPrefs.
   - Can be extended to create new achievement types.

2. AchievementManager.cs
   - Central manager for all achievements.
   - Loads and subscribes each achievement to GameEvents.
   - Keeps all achievements updated and saves progress automatically.

3. GameEvents.cs
   - Holds static Action events that achievements listen to.
   - Example events: OnRoundCompleted, OnPerfectRound, OnQuestionAnswered, etc.
   - Call these events from your own gameplay scripts when needed.

4. GoldStarAchievement.cs
   - Example implementation of an achievement with progression.
   - Unlocks at 1, 10, and 30 perfect rounds.
   - Demonstrates how to handle multi-tier achievements.

-----------------------------------------------------
⚙️ HOW TO INTEGRATE INTO YOUR GAME
-----------------------------------------------------

1. **Import the Folder**
   - Place the entire “SharedAchievements” folder into your `/Assets` directory.

2. **Set Up the Manager**
   - In your Unity scene, create an empty GameObject called **AchievementManager**.
   - Attach the `AchievementManager` script to it.

3. **Create Achievements**
   - Right-click in your Project window → `Create > Achievement > Gold Star Achievement`
   - This creates a ScriptableObject asset.
   - Assign this asset to the AchievementManager’s list in the Inspector.

4. **Connect Game Events**
   - Your game should call the appropriate GameEvents when something happens.
     For example:
       GameEvents.OnRoundCompleted?.Invoke(correctAnswers, totalQuestions);
   - The AchievementManager will forward this to all subscribed achievements.

5. **Testing Progress**
   - Run your game and trigger the achievement conditions.
   - PlayerPrefs will save the progress automatically.
   - You can clear all data by calling PlayerPrefs.DeleteAll(); if needed.

-----------------------------------------------------
🏆 GOLD STAR ACHIEVEMENT LOGIC
-----------------------------------------------------
- Unlocks when a player completes a “perfect round” (all answers correct).
- Tracks how many times this has been achieved.
- Unlock tiers:
    • Tier 1 → 1 perfect round
    • Tier 2 → 10 perfect rounds
    • Tier 3 → 30 perfect rounds

-----------------------------------------------------
💾 SAVE / LOAD DETAILS
-----------------------------------------------------
- Achievements use PlayerPrefs for lightweight persistence.
- Example:
      PlayerPrefs.SetInt("PerfectRounds", value);
      PlayerPrefs.Save();

      int rounds = PlayerPrefs.GetInt("PerfectRounds", 0);
- Each achievement manages its own save key.

-----------------------------------------------------
📢 EXTENDING THE SYSTEM
-----------------------------------------------------
To add a new achievement:
1. Create a new C# script inheriting from Achievement.
2. Override the Initialize() and CheckCondition() methods.
3. Subscribe to the event(s) relevant to your new achievement in Initialize().
4. Implement your own unlock logic in CheckCondition().
5. Create a new ScriptableObject from it and assign it to the manager.

-----------------------------------------------------
✅ NOTES
-----------------------------------------------------
- The system is decoupled and uses the Observer Pattern through C# events.
- No direct references between gameplay code and achievements.
- Achievements automatically save and load via PlayerPrefs.

=====================================================
END
=====================================================
