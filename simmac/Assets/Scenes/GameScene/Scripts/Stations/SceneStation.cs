using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStation : Station
{
    public string nameOfSceneToOpen;
    public override void OnClick()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nameOfSceneToOpen);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
