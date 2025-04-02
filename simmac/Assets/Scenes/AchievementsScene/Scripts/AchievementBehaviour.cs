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
        LoadAchievementsFromJson();
        CreateAchievementsList();
        InstantiateAchievementUI();
    }

    private void LoadAchievementsFromJson()
    {
        string jsonFilePath = Application.dataPath + "/Scenes/AchievementsScene/Jsons/Achievements.json";
        string jsonContent = File.ReadAllText(jsonFilePath);
        json = JsonNode.Parse(jsonContent);
    }

    private void CreateAchievementsList()
    {
        JsonArray jsonAchievements = json["Achievements"].AsArray();
        foreach (JsonNode achievement in jsonAchievements)
        {
            availableAchievements.Add(Achievement.readFromJson(achievement));
        }
    }

    private void InstantiateAchievementUI()
    {
        for (int i = 0; i < availableAchievements.Count; i++)
        {
            GameObject achievementBox = CreateAchievementBox();
            SetupAchievementUIElements(achievementBox, availableAchievements[i]);
        }
    }

    private GameObject CreateAchievementBox()
    {
        return GameObject.Instantiate(achievementStyling, zero, Quaternion.identity, this.transform) as GameObject;
    }

    private void SetupAchievementUIElements(GameObject achievementBox, Achievement achievement)
    {
        GameObject child;

        // Set achievement image
        achievementBox.GetComponent<Image>().sprite = achievement.Image;

        // Set title text
        child = achievementBox.transform.Find("Title").gameObject;
        child.GetComponent<TextMeshProUGUI>().text = achievement.Title;

        // Set description text
        child = achievementBox.transform.Find("Description").gameObject;
        child.GetComponent<TextMeshProUGUI>().text = achievement.Description;
    }
}
