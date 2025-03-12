using UnityEngine;
using UnityEngine.UI;
using System.Text.Json.Nodes;
using System.IO;
using System.Collections.Generic;
using TMPro;
public class AchievementBehaviour : MonoBehaviour
{
    private JsonNode json;
    public List<Achievement> availableAchievements = new List<Achievement>();
    public Object achievementStyling;
    private Vector3 zero = new Vector3(50, 571, 0);
    void Start()
    {
        json = JsonNode.Parse(File.ReadAllText(Application.dataPath + "/Scenes/AchievementsScene/Jsons/Achievements.json"));
        JsonArray jsonAchievements = json["Achievements"].AsArray();
        foreach (JsonNode achievement in jsonAchievements)
        {
            availableAchievements.Add(Achievement.readFromJson(achievement));
        }
        for (int i = 0; i < availableAchievements.Count; i++)
        {
            GameObject achievementBox = GameObject.Instantiate(achievementStyling, zero, Quaternion.identity, this.transform) as GameObject;
            GameObject child;
            achievementBox.GetComponent<Image>().sprite = availableAchievements[i].Image;
            child = achievementBox.transform.Find("Title").gameObject;
            child.GetComponent<TextMeshProUGUI>().text = availableAchievements[i].Title;
            child = achievementBox.transform.Find("Description").gameObject;
            child.GetComponent<TextMeshProUGUI>().text = availableAchievements[i].Description;
        }
    }
}
