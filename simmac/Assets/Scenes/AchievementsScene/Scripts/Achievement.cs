using System;
using UnityEngine;
using System.Text.Json.Nodes;
using MessagePack;

[Serializable]
public class Achievement
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Sprite Image { get; private set; }
    public byte State;
    private static Sprite DefaultImage = Resources.Load<Sprite>("NoImage");

    static public Achievement readFromJson(JsonNode Node)
    {
        Achievement JsonAchievement = new Achievement();
        ParseBasicProperties(JsonAchievement, Node);
        LoadAchievementImage(JsonAchievement, Node);
        return JsonAchievement;
    }

    private static void ParseBasicProperties(Achievement achievement, JsonNode node)
    {
        achievement.Title = node["Title"].GetValue<string>();
        achievement.Description = node["Description"].GetValue<string>();
    }

    private static void LoadAchievementImage(Achievement achievement, JsonNode node)
    {
        string imageFileName = node["Image"].GetValue<string>();
        string spritePath = "AchievementSprites/" + imageFileName;
        achievement.Image = Resources.Load<Sprite>(spritePath);

        if (achievement.Image == null)
        {
            achievement.Image = DefaultImage;
            LogMissingImageWarning(achievement.Title);
        }
    }

    private static void LogMissingImageWarning(string achievementTitle)
    {
        Debug.Log("Achievement " + achievementTitle + " is missing an image sprite");
    }
}
