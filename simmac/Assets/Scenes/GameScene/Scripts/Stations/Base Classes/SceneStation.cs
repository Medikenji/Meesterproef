using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStation : Station
{
    [SerializeField] private string sceneToLoad = "ChooseMinigameScene";

    // Static reference to track which scenes are loaded additively
    public static string ActiveAdditiveScene { get; private set; }

    public override void OnClick()
    {
        GameManager.instance.StopDayTime();
        StartCoroutine(LoadSceneAdditively());
    }

    private IEnumerator LoadSceneAdditively()
    {
        // Store scene name for later unloading
        ActiveAdditiveScene = sceneToLoad;

        // Load the new scene additively
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        asyncOperation.allowSceneActivation = false;

        // Wait until the scene is ready to activate
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }

        // Set the newly loaded scene as active (for rendering)
        Scene newlyLoadedScene = SceneManager.GetSceneByName(sceneToLoad);
        SceneManager.SetActiveScene(newlyLoadedScene);
    }

    /// <summary>
    /// Call this method when returning from an additively loaded scene
    /// </summary>
    public static IEnumerator ReturnToMainScene()
    {
        GameManager.instance.StartDayTime();
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
            while (!loadOperation.isDone)
            {
                yield return null;
            }
        }

        Scene gameScene = SceneManager.GetSceneByName("GameScene");
        if (gameScene.IsValid())
        {
            GameObject[] rootObjects = gameScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}
