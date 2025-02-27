using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void SwitchScene(string SceneName)
    {
        Debug.Log("Switching Scene to " + SceneName);
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Program closed by user");
        Application.Quit();
    }
}
