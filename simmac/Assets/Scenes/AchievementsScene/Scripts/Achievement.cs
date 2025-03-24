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
        JsonAchievement.Title = Node["Title"].GetValue<string>();
        JsonAchievement.Description = Node["Description"].GetValue<string>();
        string spritePath = "AchievementSprites/" + Node["Image"].GetValue<string>();
        JsonAchievement.Image = Resources.Load<Sprite>(spritePath);
        if (JsonAchievement.Image == null)
        {
            JsonAchievement.Image = DefaultImage;
            Debug.Log("Achievement " + JsonAchievement.Title + " is missing an image sprite");
        }
        return JsonAchievement;
    }
}
