using UnityEngine;

public class Counter : MonoBehaviour
{
    private float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime; // Accumulate time
        if (timer >= 1f) // Check if 1 second has passed
        {
            AchievementEvents.OnSecondPassed.Invoke();
            timer = 0f; // Reset the timer
        }
    }
}
