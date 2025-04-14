using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStation : Station
{
    private string sceneToLoad = "ChooseMinigameScene";

    public override void OnClick()
    {
        GameManager.instance.StopDayTime();
        StartCoroutine(LoadSceneAdditively());
    }

    private IEnumerator LoadSceneAdditively()
    {
        GameManager.instance.ActiveAdditiveScene = sceneToLoad;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;

        // Wait until the scene is ready to be activated
        // The 'yield return null' pauses execution of this coroutine until the next frame,
        // allowing Unity to continue loading the scene in the background while the game keeps running.
        // This creates non-blocking behavior so the game remains responsive during loading.
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }

        Scene newlyLoadedScene = SceneManager.GetSceneByName(sceneToLoad);
        SceneManager.SetActiveScene(newlyLoadedScene);
    }
}
