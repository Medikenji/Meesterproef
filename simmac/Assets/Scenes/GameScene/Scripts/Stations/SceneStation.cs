using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStation : Station
{
    public string nameOfSceneToOpen { get; set; }

    public override void OnClick()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        if (nameOfSceneToOpen.Length == 0)
        {
            print($"{gameObject.name} has no scene name specified.");
            yield break;
        }

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
