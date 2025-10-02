using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;


public static class Achievements
{
    public static Dictionary<AchievementType, Achievement> nameToAchievement = new Dictionary<AchievementType, Achievement>(); //will be used to access achievements
    private static TextAsset jsonFile = Resources.Load<TextAsset>("Achievements"); //should read jsonfile from the resources folder
    private static string path = Path.Combine(Application.persistentDataPath, "Achievements.json"); //location of existing player saved data
    public static void ReadData()
    {
        string jsonText = null;
        
        if (jsonFile == null && !File.Exists(path))//if json file is not in resources folder or has a different name
        {
            Debug.LogError("No Achievements file found in resources folder and persistent path");
            return;
        }

        if (File.Exists(path))
        {
            jsonText = File.ReadAllText(path);
            Debug.Log($"Loaded achievements from persistent path: {path}");
        }
        else
        {
            jsonText = jsonFile.text;
            Debug.Log("Loaded Achievements from resources");
        }
        AchievementsJsonData ajd = JsonUtility.FromJson<AchievementsJsonData>(jsonText);
        
        Debug.Log("Raw JSON: " + jsonText); // a check to make sure the raw json file can be read
        
        if (ajd == null ) // if json cant be parsed
        {
            Debug.LogError("Failed to parse achievements JSON ");
            return;
        }
        if (ajd.Achievements == null) //if the list does not get filled
        {
            Debug.LogError("Achievements' list is null.");
            return;
        }
        
        
        foreach (AchievementJsonData achievementData in ajd.Achievements)
        {
            if (Enum.TryParse(achievementData.AchievementType, out AchievementType achievementType)) //successfull loading of achievment data
            {
                Debug.Log($"Parsed Achievement: {achievementType} - {achievementData.Title} - {achievementData.Description} -  {achievementData.Status}");
                CreateAchievement(achievementType, achievementData.Title,  achievementData.Description,  achievementData.Status);
            }
            else //unknown achievements in the json file
            {
                Debug.LogWarning($"Unknown AchievementType: {achievementData.AchievementType}");
            }
        }
    }

    public static void SaveData()
    {
        AchievementsJsonData wrapper = new AchievementsJsonData();
        wrapper.Achievements = new List<AchievementJsonData>();

        foreach (Achievement ach in nameToAchievement.Values)
        {
            Achievement achievementData = ach;
            AchievementJsonData ajd = new AchievementJsonData
            {
                AchievementType = ach.Type.ToString(),
                Title = ach.Title, 
                Description = ach.Description,
                Status = ach.Status
                
            };
            wrapper.Achievements.Add(ajd);
        }
        
        // Serialize to JSON (pretty print for easier debugging)
        string json = JsonUtility.ToJson(wrapper, true);

        // Write to persistent data path so it works at runtime
        File.WriteAllText(path, json);

        Debug.Log($"Achievements saved to: {path}");
    }
    
    private static void CreateAchievement(AchievementType achievementType, string title, string description, int status)
    {
        if (nameToAchievement.ContainsKey(achievementType))
        {
            Debug.LogError("Achievement already exists");
        }
        Achievement newAchievement = new Achievement(achievementType, title, description, status);
        nameToAchievement.Add(achievementType, newAchievement);
    }
}
/*
 * {
  "Achievements": [
    {
      "AchievementType": "PlatinumMath",
      "Title": "Platinum Math",
      "Description": "Earn all achievements",
      "Status": 0
    },
    {
      "AchievementType": "Mathematician",
      "Title": "Mathematician",
      "Description": "Play for 20 minutes or more",
      "Status": 0
    },
    {
      "AchievementType": "BuzzerBeater",
      "Title": "Buzzer Beater",
      "Description": "Answer any question correctly at the last second",
      "Status": 0
    },
    {
      "AchievementType": "GoldStar",
      "Title": "Gold Star",
      "Description": "Answer all questions in a round x times",
      "Status": 0
    },
    {
      "AchievementType": "MathMaster",
      "Title": "Math Master",
      "Description": "Answer x questions correctly",
      "Status": 0
    },
    {
      "AchievementType": "Speedster",
      "Title": "Speedster",
      "Description": "Answer all questions in a round correctly in less than 10 seconds",
      "Status": 0
    },
    {
      "AchievementType": "Huh",
      "Title": "Huh?",
      "Description": "During a round click on the equation",
      "Status": 0
    }
  ]
}
 */
