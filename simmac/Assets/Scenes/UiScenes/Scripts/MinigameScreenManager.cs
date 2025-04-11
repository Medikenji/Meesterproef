using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameScreenManager : MonoBehaviour
{
    public Button regularBtn, redBtn, greenBtn, blueBtn, exitBtn;

    void Start()
    {
        regularBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Default
            ));

        redBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Red
            ));

        greenBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Green)
            );

        blueBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Blue
            ));

        exitBtn.onClick.AddListener(() => StartCoroutine(UnloadAdditiveScene()));
    }

    public void StartMinigame(OrderableItem.Type type, OrderableItem.Modifier mod)
    {
        print($"Playing {type} with {mod}");
    }

    public IEnumerator UnloadAdditiveScene()
    {
        if (string.IsNullOrEmpty(GameManager.instance.ActiveAdditiveScene))
        {
            Debug.LogWarning("No active additive scene to unload.");
            yield break;
        }

        GameManager.instance.StartDayTime();

        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(GameManager.instance.ActiveAdditiveScene);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
        GameManager.instance.ActiveAdditiveScene = null;

        while (!asyncUnload.isDone)
        {
            yield return null;
        }


    }
}
