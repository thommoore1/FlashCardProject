using System;
using System.Net.Mail;

[Serializable]
public class Achievement
{
    public AchievementType Type;
    public string Title;
    public string Description;
    public int Status;
    public bool IsCompleted;

    public Achievement(AchievementType type,string title, string description, int status)
    {
        Type = type;
        Title = title;
        Description = description;
        Status = status;
        completion();
        
    }

    private void multiStage()
    {
        if (Type == AchievementType.GoldStar)
        {
            if (Status >= 30)
            {
                Title = "Gold Star";
                Description = $"You have answered all questions in a round {Status} times";
                IsCompleted = true;
            }
            else if (Status >= 10 && Status < 30)
            {
                Title = "Gold Star 3";
                Description = "Answer all questions in a round 30 times";
                IsCompleted = false;
            }
            else if (Status < 10 && Status >= 1)
            {
                Title = "Gold Star 2";
                Description = "Answer all questions in a round 10 times";
                IsCompleted = false;
            }
            else
            {
                Title = "Gold Star 1";
                Description = "Answer all questions in a round 1 time";
                IsCompleted = false;
            }
        }
        else if(Type == AchievementType.MathMaster)
        {
            if (Status >= 100)
            {
                Title = "Math Master";
                Description = $"You have answered {Status} questions correctly";
                IsCompleted = true;
            }
            else if (Status >= 50 && Status < 100)
            {
                Title = "Math Master 3";
                Description = "Answer 100 questions correctly";
                IsCompleted = false;
            }
            else if (Status < 50 && Status >= 10)
            {
                Title = "Math Master 2";
                Description = "Answer 50 questions correctly";
                IsCompleted = false;
            }
            else
            {
                Title = "Math Master 1";
                Description = "Answer 10 questions correctly";
                IsCompleted = false;
            }
        }
    }

    private void completion()
    {
        if (Status == 1)
        {
            IsCompleted = true;
        }
        else
        {
            IsCompleted = false;
        }
        multiStage();
    }
}
