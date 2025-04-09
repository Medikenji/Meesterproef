using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void StartScene()
    {
        GameManager.instance.LoadGame();
        if (GameManager.instance.current_state.state == GameManager.State.NewSave || GameManager.instance.current_state.state == GameManager.State.InGame)
        {
            SceneManager.LoadScene("GameScene");
        }
        if (GameManager.instance.current_state.state == GameManager.State.InMenu || GameManager.instance.current_state.state == GameManager.State.GameOver)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Program closed by user");
        Application.Quit();
    }
}
