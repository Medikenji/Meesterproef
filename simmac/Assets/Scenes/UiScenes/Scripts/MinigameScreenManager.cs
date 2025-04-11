using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameScreenManager : MonoBehaviour
{
    public Button regularBtn, redBtn, greenBtn, blueBtn, exitBtn;
    private static string loadedMinigameScene;

    void Start()
    {
        regularBtn.onClick.AddListener(() => StartMinigame(OrderableItem.Modifier.Default));
        redBtn.onClick.AddListener(() => StartMinigame(OrderableItem.Modifier.Red));
        greenBtn.onClick.AddListener(() => StartMinigame(OrderableItem.Modifier.Green));
        blueBtn.onClick.AddListener(() => StartMinigame(OrderableItem.Modifier.Blue));

        // Use SceneStation's return method instead of replacing scene
        exitBtn.onClick.AddListener(() => StartCoroutine(ReturnToGameScene()));
    }

    private void StartMinigame(OrderableItem.Modifier mod)
    {
        GameManager.instance.minigameAttributes.modifier = mod;

        // Determine which minigame scene to load
        string sceneToLoad = GetMinigameSceneName(GameManager.instance.minigameAttributes.type);

        // Start coroutine to load the minigame additively
        StartCoroutine(LoadMinigameAdditively(sceneToLoad));
    }

    private string GetMinigameSceneName(OrderableItem.Type type)
    {
        switch (type)
        {
            case OrderableItem.Type.Burger:
                return "BurgerStack";
            case OrderableItem.Type.Fries:
                return "PFIB";
            case OrderableItem.Type.Milkshake:
                return "ShakeShifter";
            case OrderableItem.Type.Icecream:
                return "SniperShowdown";
            default:
                Debug.LogError("Unknown minigame type: " + type);
                return string.Empty;
        }
    }

    private IEnumerator LoadMinigameAdditively(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
            yield break;

        // Store scene name for later unloading
        loadedMinigameScene = sceneName;

        // Load minigame scene additively
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        asyncOperation.allowSceneActivation = false;

        // Wait until the scene is ready
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }

        // Set the minigame scene as active for rendering
        // Deactivate all root GameObjects in the GameScene to effectively hide it
        Scene gameScene = SceneManager.GetSceneByName("GameScene");
        if (gameScene.IsValid())
        {
            GameObject[] rootObjects = gameScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                obj.SetActive(false);
            }
        }

        Scene minigameScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(minigameScene);
    }

    /// <summary>
    /// Return to the main game scene by unloading both the minigame selection and any active minigame
    /// </summary>
    private IEnumerator ReturnToGameScene()
    {
        // First unload any active minigame
        if (!string.IsNullOrEmpty(loadedMinigameScene))
        {
            AsyncOperation minigameUnloadOperation = SceneManager.UnloadSceneAsync(loadedMinigameScene);
            while (!minigameUnloadOperation.isDone)
            {
                yield return null;
            }
            loadedMinigameScene = null;
        }

        // Now return to main scene using SceneStation's method
        yield return StartCoroutine(SceneStation.ReturnToMainScene());
    }

    /// <summary>
    /// Call this from minigame scenes to return to the minigame selection screen
    /// </summary>
    public static IEnumerator ReturnToMinigameSelection()
    {
        if (!string.IsNullOrEmpty(loadedMinigameScene))
        {
            // Unload the minigame scene
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(loadedMinigameScene);

            while (!unloadOperation.isDone)
            {
                yield return null;
            }

            loadedMinigameScene = null;

            // Set the minigame selection scene as active again
            Scene selectionScene = SceneManager.GetSceneByName(SceneStation.ActiveAdditiveScene);
            SceneManager.SetActiveScene(selectionScene);
        }
    }
}
