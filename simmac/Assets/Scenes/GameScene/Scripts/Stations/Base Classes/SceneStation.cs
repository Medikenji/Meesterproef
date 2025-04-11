using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStation : Station
{
    [SerializeField] private string sceneToLoad = "ChooseMinigameScene";

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
